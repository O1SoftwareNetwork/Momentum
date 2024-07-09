// run-migrations.fsx
#r "nuget: Npgsql"
#r "nuget: Microsoft.Extensions.Configuration.Json"
#r "nuget: Microsoft.Extensions.Configuration"

open System
open System.IO
open Microsoft.Extensions.Configuration
open Npgsql

type Migration =
    { Id: string
      UpFilePath: string
      DownFilePath: string }

let loadMigrationScripts path =
    Directory.GetFiles(path, "*_Up.sql")
    |> Array.map (fun upFilePath ->
        let fileNameWithoutExtension =
            Path.GetFileNameWithoutExtension(upFilePath).Replace("_Up", "")

        let downFilePath =
            Path.Combine(path, sprintf "%s_Down.sql" fileNameWithoutExtension)

        { Id = fileNameWithoutExtension
          UpFilePath = upFilePath
          DownFilePath = downFilePath })

let runMigrations (connectionString: string) (migrations: Migration list) =
    use connection = new NpgsqlConnection(connectionString)
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

        let exists = command.ExecuteScalar() :?> int64 > 0L

        if not exists then
            let upScript = File.ReadAllText(migration.UpFilePath)
            command.CommandText <- upScript
            command.ExecuteNonQuery() |> ignore

            command.CommandText <-
                "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES (@id, @version);"

            command.Parameters.Clear()
            command.Parameters.AddWithValue("@id", migration.Id) |> ignore
            command.Parameters.AddWithValue("@version", "1.0.0") |> ignore
            command.ExecuteNonQuery() |> ignore

    printfn "Migrations completed."

// Determine the absolute path to the configuration file
let baseDirectory = Directory.GetCurrentDirectory()

let configFilePath =
    Path.Combine(baseDirectory, "backend", "server", "appsettings.json")

let configuration =
    ConfigurationBuilder()
        .AddJsonFile(configFilePath, optional = false, reloadOnChange = true)
        .Build()

let connectionString = configuration.GetConnectionString("DefaultConnection")

let migrations =
    loadMigrationScripts (Path.Combine(baseDirectory, "backend", "server", "migrations"))
    |> List.ofArray

runMigrations connectionString migrations
