let rec solve () =
    match stdin.ReadLine() with
    | "0" -> ()
    | x ->
        let [| n; p |] = x.Split() |> Array.map int
        let a = if p % 2 = 0 then p - 1 else p

        [ a; a + 1; n - a; n - a + 1 ]
        |> List.filter (fun x -> x <> p)
        |> List.sort
        |> List.map string
        |> String.concat " "
        |> printfn "%s"

        solve ()

solve ()
