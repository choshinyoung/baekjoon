let n = stdin.ReadLine() |> int

let score [| x: double; y: double |] =
    let d = x * x + y * y |> sqrt

    if d <= 3 then 100
    elif d <= 6 then 80
    elif d <= 9 then 60
    elif d <= 12 then 40
    elif d <= 15 then 20
    else 0

for _ in 1..n do
    let [| p1; p2 |] =
        stdin.ReadLine().Split()
        |> Array.map double
        |> Array.chunkBySize 2
        |> Array.chunkBySize 3
        |> Array.map (Array.map score >> Array.sum)

    let result =
        match p1.CompareTo p2 with
        | x when x > 0 -> "PLAYER 1 WINS"
        | x when x < 0 -> "PLAYER 2 WINS"
        | _ -> "TIE"

    printfn $"SCORE: {p1} to {p2}, {result}."
