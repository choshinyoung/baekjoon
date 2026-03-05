let rec solve () =
    let [| a; b |] = stdin.ReadLine().Split() |> Array.map int

    if a <> 0 && b <> 0 then
        printfn "%d %d / %d" (a / b) (a % b) b
        solve ()

solve ()
