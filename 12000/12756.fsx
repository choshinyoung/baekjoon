let [| d1; h1 |] = stdin.ReadLine().Split() |> Array.map int
let [| d2; h2 |] = stdin.ReadLine().Split() |> Array.map int

match compare ((h1 + d2 - 1) / d2) ((h2 + d1 - 1) / d1) with
| 1 -> printfn "PLAYER A"
| -1 -> printfn "PLAYER B"
| _ -> printfn "DRAW"
