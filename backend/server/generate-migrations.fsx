open System.IO
open System

type Migration =
    { Id: string; Up: string; Down: string }

// Sample migrations
let migrations =
    [ { Id = "202307080001_CreateUserTable"
        Up =
          """
            CREATE TABLE Users (
                Id UUID PRIMARY KEY,
                Username VARCHAR(30) NOT NULL,
                Password TEXT NOT NULL,
                Image TEXT NOT NULL
            );
            """
        Down = "DROP TABLE Users;" }
      // Add more migrations as needed
      ]

// Function to generate unique migration ID
let generateMigrationId () =
    let now = DateTime.UtcNow
    now.ToString("yyyyMMddHHmmss")

// Function to create migration files
let createMigrationFile (migration: Migration) =
    let fileName = sprintf "%s.sql" migration.Id

    // Ensure the directory exists or create it
    let directoryPath = "backend/server/migrations"

    if not <| Directory.Exists(directoryPath) then
        Directory.CreateDirectory(directoryPath) |> ignore

    // Construct file paths
    let upFilePath = Path.Combine(directoryPath, sprintf "%s_Up.sql" fileName)
    let downFilePath = Path.Combine(directoryPath, sprintf "%s_Down.sql" fileName)

    // Write SQL scripts to files
    File.WriteAllText(upFilePath, migration.Up)
    File.WriteAllText(downFilePath, migration.Down)

    printfn "Created migration files: %s and %s" upFilePath downFilePath


// Generate migration files for all migrations
List.iter createMigrationFile migrations
