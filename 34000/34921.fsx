let [| a; t |] = stdin.ReadLine().Split() |> Array.map int
max 0 (10 + 2 * (25 - a + t)) |> printfn "%d"
