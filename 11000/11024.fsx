for _ in 1 .. stdin.ReadLine() |> int do
    stdin.ReadLine().Split() |> Array.map int |> Array.sum |> printfn "%d"
