stdin.ReadLine() |> ignore
let a = stdin.ReadLine().Split() |> Array.map int
Array.sum a - Array.max a |> printfn "%d"
