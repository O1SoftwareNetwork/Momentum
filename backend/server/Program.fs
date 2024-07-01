module Program

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe

let apiRoutes: HttpHandler =
  subRoute
    "/api"
    (choose [ GET
              >=> choose [ route "/health"
                           >=> json {| message = "API is in good health" |} ] ])

let webApp =
  (choose [ GET
            >=> choose [ route "/" >=> htmlFile "./pages/index.html" ]
            apiRoutes
            setStatusCode 404 >=> text "Not Found" ])

let configureApp (app: IApplicationBuilder) =
  // Add Giraffe to the ASP.NET Core pipeline
  app.UseGiraffe webApp

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
