module APIServer

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open System
open System.Configuration
open Microsoft.Extensions.Logging
open User.Domain
open Microsoft.Extensions.Configuration
open MigrationRunner

Console.WriteLine "Server is working fine"

let errorHandler (ex: Exception) (logger: ILogger) =
  logger.LogError(EventId(), ex, "An unhandled exception has occurred while executing the request.")
  clearResponse >=> setStatusCode 500 >=> json {| message = ex.Message |}

let sendHealthMessage =
  fun next ctx ->
    json
      {|
        message = "The API routes are working as expected"
      |}
      next
      ctx


let sendTestMessage =
  fun _ next ->
    failwith "Testing failed message"
    earlyReturn next


let sendUsers =
  fun next ctx ->
    let mockUsers: User list = [
      {
        id = Guid.NewGuid()
        firstName = "John"
        lastNAme = "Doe"
        username = "J_doe"
        password = "Password1"
        email = "jdoe@sample.com"
        profile_image = ""
        created_at = DateTime.Now
        updated_at = DateTime.Now
      }
    ]

    json mockUsers next ctx

let healthRoutes: HttpHandler =
  choose [
    route "/health" >=> sendHealthMessage
  ]

let testRoutes: HttpHandler =
  choose [ route "/fail" >=> sendTestMessage ]

let userRoutes: HttpHandler =
  choose [ route "" >=> sendUsers ]

let apiRoutes: HttpHandler =
  subRoute
    "/api"
    (choose [
      GET >=> healthRoutes
      GET >=> testRoutes
      subRoute "/users" (choose [ GET >=> userRoutes ])
    ])

let webApp =
  choose [
    GET
    >=> choose [
      route "/" >=> htmlFile "./pages/index.html"
    ]
    apiRoutes
    setStatusCode 404 >=> text "Not Found"
  ]

let configureApp (app: IApplicationBuilder) =
  // Add Giraffe to the ASP.NET Core pipeline
  app
    .UseGiraffeErrorHandler(errorHandler)
    .UseGiraffe
    webApp

let configureLogging (builder: ILoggingBuilder) =
  // Configure the logging factory
  builder
    .AddConsole() // Set up the Console logger
    .AddDebug() // Set up the Debug logger

  // Add additional loggers if wanted...
  |> ignore

let configureServices (services: IServiceCollection) =

  let configuration =
    ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional = false, reloadOnChange = true)
      .AddEnvironmentVariables()
      .Build()

  let connectionString =
    configuration.GetConnectionString("DefaultConnection")

  runMigrations connectionString migrations

  // Add Giraffe dependencies
  services.AddGiraffe() |> ignore

let hostBuilder (webHostBuilder: IWebHostBuilder) =
  webHostBuilder
    .Configure(configureApp)
    .ConfigureLogging(configureLogging)
    .ConfigureServices(configureServices)

[<EntryPoint>]
let main _ =
  Host
    .CreateDefaultBuilder()
    .ConfigureWebHostDefaults(fun hb -> hostBuilder hb |> ignore)
    .Build()
    .Run()

  0
