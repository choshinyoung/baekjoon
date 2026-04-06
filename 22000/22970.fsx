stdin.ReadLine() |> ignore
let a = stdin.ReadLine().Split() |> Array.map int

let l =
    a
    |> Array.pairwise
    |> Array.scan (fun acc (x, y) -> if x < y then acc + 1 else 1) 1

let r =
    a
    |> Array.pairwise
    |> fun p ->
        Array.scanBack (fun (x, y) acc -> if x > y then acc + 1 else 1) p 1

(l, r) ||> Array.map2 (fun x y -> x + y - 1) |> Array.max |> printfn "%d"
