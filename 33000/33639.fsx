open System

let [| n; q |] = stdin.ReadLine().Split() |> Array.map int
let initials = Array.init n (fun _ -> stdin.ReadLine())

for _ in 1..q do
    let initial = stdin.ReadLine()

    match
        initials
        |> Array.filter (fun x ->
            initial = (x.Split() |> Array.map Seq.head |> String))
    with
    | [||] -> printfn "nobody"
    | [| x |] -> printfn "%s" x
    | _ -> printfn "ambiguous"
