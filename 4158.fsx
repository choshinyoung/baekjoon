open System
open System.IO
open System.Collections.Generic

let stream = new StreamReader(Console.OpenStandardInput())

while true do
    let [| n; m |] = stream.ReadLine().Split() |> Array.map int

    if n = 0 then
        exit 0

    let s = List.init n (fun _ -> stream.ReadLine() |> int) |> HashSet<int>

    List.init m (fun _ -> stream.ReadLine() |> int)
    |> List.filter s.Contains
    |> List.length
    |> printfn "%d"
