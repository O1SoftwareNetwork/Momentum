module server.test

open Xunit
open Swensen.Unquote
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.TestHost
open System.Text.Json
open User.Domain
open System

[<Fact>]
let `` API Health test `` () =

    let webHostBuilder = new WebHostBuilder() |> APIServer.hostBuilder

    let server = new TestServer(webHostBuilder)
    let client = server.CreateClient()

    let response =
        task {
            let! response = client.GetAsync(@"\api\health")
            let! stringContent = response.Content.ReadAsStringAsync()
            return stringContent
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously

    test <@ response = "{\"message\":\"The API routes are working as expected\"}" @>

[<Fact>]
let `` API Fail Check `` () =

    let webHostBuilder = new WebHostBuilder() |> APIServer.hostBuilder

    let server = new TestServer(webHostBuilder)
    let client = server.CreateClient()

    let response =
        task {
            let! response = client.GetAsync(@"\api\fail")
            let! content = response.Content.ReadAsStringAsync()
            return content
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously

    test <@ response = "{\"message\":\"Testing failed message\"}" @>
