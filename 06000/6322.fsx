open System

Seq.initInfinite (fun _ -> stdin.ReadLine().Split() |> Array.map double)
|> Seq.takeWhile (fun x -> x[0] <> 0)
|> Seq.map (function
    | [| -1.0; b; c |] -> 'a', c * c - b * b
    | [| a; -1.0; c |] -> 'b', c * c - a * a
    | [| a; b; -1.0 |] -> 'c', a * a + b * b)
|> Seq.iteri (fun i (s, a) ->
    printfn $"Triangle #{i + 1}"

    if a <= 0 then
        printfn "Impossible.\n"
    else
        printfn $"{s} = %.3f{sqrt a}\n")
