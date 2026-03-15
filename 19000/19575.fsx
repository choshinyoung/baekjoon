let [| n; x |] = stdin.ReadLine().Split() |> Array.map int64

Seq.init (int n + 1) (fun _ -> stdin.ReadLine().Split()[0] |> int64)
|> Seq.fold (fun acc a -> (acc * x + a) % 1000000007L) 0L
|> printfn "%d"
