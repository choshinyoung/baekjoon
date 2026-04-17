let dist2 x1 y1 x2 y2 = pown (x1 - x2) 2 + pown (y1 - y2) 2

let t = stdin.ReadLine() |> int

for _ in 1..t do
    let [| x1; y1; x2; y2 |] = stdin.ReadLine().Split() |> Array.map int
    let n = stdin.ReadLine() |> int

    Array.init n (fun _ -> stdin.ReadLine().Split() |> Array.map int)
    |> Array.filter (fun [| cx; cy; r |] ->
        dist2 x1 y1 cx cy <= r * r <> (dist2 x2 y2 cx cy <= r * r))
    |> Array.length
    |> printfn "%d"
