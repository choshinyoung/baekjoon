let rec solve () =
    match stdin.ReadLine() |> int with
    | 0 -> ()
    | x ->
        (x + 1) / 2 |> printfn "%d"
        solve ()

solve ()
