let input () =
    stdin.ReadLine().Split ":"
    |> Array.map int
    |> fun [| a; b; c |] -> a * 60 * 60 + b * 60 + c

let calc a =
    [ a / (60 * 60 * 12); a / (60 * 60); a / 60 ]

(input () |> calc, input () |> calc)
||> List.map2 (fun a b -> b - a)
|> List.map string
|> String.concat " "
|> printfn "%s"
