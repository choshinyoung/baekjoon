stdin.ReadLine() |> ignore

(stdin.ReadLine().Split() |> Array.map int |> Array.sort |> Array.rev,
 stdin.ReadLine().Split() |> Array.map int |> Array.sort)
||> Array.fold2 (fun acc x y -> acc + x * y) 0
|> printfn "%d"
