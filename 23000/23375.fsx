let [| x; y |] = stdin.ReadLine().Split() |> Array.map int
let r = stdin.ReadLine() |> int

printfn "%d %d" (x - r) (y - r)
printfn "%d %d" (x + r) (y - r)
printfn "%d %d" (x + r) (y + r)
printfn "%d %d" (x - r) (y + r)
