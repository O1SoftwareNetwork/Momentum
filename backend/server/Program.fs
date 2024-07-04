module APIServer

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open System
open Microsoft.Extensions.Logging

Console.WriteLine "Server is working fine"

let errorHandler (ex: Exception) (logger: ILogger) =
  logger.LogError(EventId(), ex, "An unhandled exception has occurred while executing the request.")
  clearResponse >=> setStatusCode 500 >=> json {| message = ex.Message |}

let sendHealthMessage =
  fun ctx next -> json {| message = "The API routes are working as expected" |} ctx next

let sendTestMessage =
  fun _ next ->
    failwith "Testing failed message"
    earlyReturn next

let apiRoutes: HttpHandler =
  subRoute
    "/api"
    (choose
      [ GET >=> choose [ route "/health" >=> sendHealthMessage ]
        GET >=> choose [ route "/fail" >=> sendTestMessage ] ])

let webApp =
  (choose
    [ GET >=> choose [ route "/" >=> htmlFile "./pages/index.html" ]
      apiRoutes
      setStatusCode 404 >=> text "Not Found" ])

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
