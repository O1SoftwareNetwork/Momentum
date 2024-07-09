module MigrationRunner

open System
open System.IO
open Npgsql

type Migration = { Id: string; Up: string; Down: string }

let migrations = [
  {
    Id = "202307080001_CreateUserTable"
    Up =
      """
            CREATE TABLE Users (
                Id UUID PRIMARY KEY,
                Username VARCHAR(30) NOT NULL,
                Password TEXT NOT NULL,
                Image TEXT NOT NULL
            );
            """
    Down = "DROP TABLE Users;"
  }
]

let loadMigrationScripts path =
  Directory.GetFiles(path, "*.sql")
  |> Array.map (fun filePath ->
    let fileName =
      Path.GetFileNameWithoutExtension(filePath)

    let script = File.ReadAllText(filePath)

    {
      Id = fileName
      Up = script
      Down = ""
    })

let runMigrations (connectionString: string) (migrations: Migration list) =
  use connection =
    new NpgsqlConnection(connectionString)

  connection.Open()

  let command = connection.CreateCommand()

  command.CommandText <-
    """
        CREATE TABLE IF NOT EXISTS __EFMigrationsHistory (
            MigrationId TEXT PRIMARY KEY,
            ProductVersion TEXT NOT NULL
        );
        """

  command.ExecuteNonQuery() |> ignore

  for migration in migrations do
    command.CommandText <- "SELECT COUNT(*) FROM __EFMigrationsHistory WHERE MigrationId = @id;"
    command.Parameters.Clear()
    command.Parameters.AddWithValue("@id", migration.Id) |> ignore

    let exists =
      command.ExecuteScalar() :?> int64 > 0L

    if not exists then
      command.CommandText <- migration.Up
      command.ExecuteNonQuery() |> ignore

      command.CommandText <-
        "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES (@id, @version);"

      command.Parameters.Clear()
      command.Parameters.AddWithValue("@id", migration.Id) |> ignore
      command.Parameters.AddWithValue("@version", "1.0.0") |> ignore
      command.ExecuteNonQuery() |> ignore
