let [| a; b |] = stdin.ReadLine().Split() |> Array.map int

let s =
    [ 1..10 ]
    |> List.collect (fun x ->
        if x = a && x = b then []
        elif x = a || x = b then [ x ]
        else [ x; x ])
    |> List.toArray

let p =
    [ 0..17 ]
    |> List.collect (fun x ->
        [ x + 1 .. 17 ] |> List.map (fun y -> s[x], s[y]))
    |> List.filter (fun (x, y) ->
        if a = b && x = y then a > x
        elif a = b then true
        elif x = y then false
        else (a + b) % 10 > (x + y) % 10)
    |> List.length

double p / double 153 |> printfn "%.3f"
