let [| a; b |] = stdin.ReadLine().Split() |> Array.map int64

let count n =
    [ 0..54 ]
    |> List.sumBy (fun i ->
        let c = 1L <<< i
        let d = 1L <<< i + 1
        (n + 1L) / d * c + max 0L ((n + 1L) % d - c))

count b - count (a - 1L) |> printfn "%d"
