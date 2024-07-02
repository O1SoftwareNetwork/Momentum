module server.test

open Xunit
open Swensen.Unquote
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.TestHost

[<Fact>]
let `` API Health test `` () =
    let webHostBuilder = new WebHostBuilder() |> APIServer.hostBuilder

    let server = new TestServer(webHostBuilder)
    let client = server.CreateClient()

    let response =
        task {
            let! response = client.GetAsync(@"\api\health")
            let! content = response.Content.ReadAsStringAsync()
            return content
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

[<Fact>]
let `` Can say Hello`` () = Assert.Equal("Hello", "Hello")
