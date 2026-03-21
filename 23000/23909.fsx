for c in 1 .. stdin.ReadLine() |> int do
    stdin.ReadLine() |> ignore

    stdin.ReadLine().Split()
    |> Array.map int
    |> (fun x -> Array.append x [| -1 |])
    |> Array.pairwise
    |> Array.fold
        (fun (count, mx) (a, b) ->
            if a > mx && a > b then count + 1, a else count, max mx a)
        (0, -1)
    |> fst
    |> printfn "Case #%d: %d" c
