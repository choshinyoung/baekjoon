stdin.ReadLine() |> ignore
let g = stdin.ReadLine() |> int

stdin.ReadLine().Split()
|> Array.filter (fun x -> int x > g)
|> Array.length
|> (+) 1
|> printfn "%d"
