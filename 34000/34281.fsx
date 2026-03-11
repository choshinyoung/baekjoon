Array.init 2 (fun _ -> stdin.ReadLine() |> int)
|> Array.fold (*) 1
|> printfn "%d"
