Array.init (stdin.ReadLine() |> int) (fun _ -> stdin.ReadLine())
|> Array.sortBy (fun x -> x.Split() |> Array.rev)
|> Array.iter (printfn "%s")
