let k = stdin.ReadLine() |> int

for i in 1..k do
    let n = stdin.ReadLine() |> int

    let phrases =
        Array.init n (fun _ -> stdin.ReadLine(), stdin.ReadLine() |> int)

    let speech = stdin.ReadLine()

    let rec count (s: string) (x: string) acc =
        match s.IndexOf x with
        | -1 -> acc
        | n -> count (s.Substring(n + 1)) x (acc + 1)

    phrases
    |> Array.sumBy (fun (x, s) -> count speech x 0 * s)
    |> printfn "Data Set %d:\n%d" i
