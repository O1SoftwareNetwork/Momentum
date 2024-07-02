module Program

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open System
open Microsoft.Extensions.Logging

let errorHandler (ex: Exception) (logger: ILogger) =
  logger.LogError(EventId(), ex, "An unhandled exception has occurred while executing the request.")
  clearResponse >=> json {| message = ex.Message |}

let sendHealthMessage =
  fun ctx next ->
    failwith "Can't do this" |> ignore
    ctx next

let sendTestMessage =
  fun ctx next -> json {| message = "Test is good" |} ctx next

let apiRoutes: HttpHandler =
  subRoute
    "/api"
    (choose
      [ GET >=> choose [ route "/health" >=> sendHealthMessage ]
        GET >=> choose [ route "/test" >=> sendTestMessage ] ])

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

let configureServices (services: IServiceCollection) =
  // Add Giraffe dependencies
  services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
  Host
    .CreateDefaultBuilder()
    .ConfigureWebHostDefaults(fun webHostBuilder ->
      webHostBuilder
        .Configure(configureApp)
        .ConfigureServices(configureServices)
      |> ignore)
    .Build()
    .Run()

  0
