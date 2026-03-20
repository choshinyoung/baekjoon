let rec solve () =
    let [| a; b |] = stdin.ReadLine().Split() |> Array.map int64

    if a <> 0 then
        if a % b = 0 then printfn "%d" (a / b)
        elif b % a = 0 then printfn "%d" (b / a)
        else printfn "%d" (a * b)

        solve ()

solve ()
