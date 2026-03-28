let rec solve c (a: string) =
    if a.Length = 1 then
        c
    else
        a
        |> Seq.fold (fun acc x -> acc * (int x - int '0')) 1
        |> string
        |> solve (c + 1)

stdin.ReadLine() |> solve 0 |> printfn "%d"
