open System

let n = Console.ReadLine() |> int
let a = Console.ReadLine().Split() |> Array.map int64 |> Array.sort

[ 0 .. n - 2 ]
|> List.map (fun i ->
    let rec search x y mx my =
        if x = i || y = i then
            mx, my
        else
            let p = a[x] + a[i] + a[y]
            let m = a[mx] + a[i] + a[my]

            let x', y' = if p > 0 then x, y - 1 else x + 1, y
            let mx', my' = if abs m < abs p then mx, my else x, y

            search x' y' mx' my'

    let x, y = 0, n - 1
    let mx, my = search x y x y
    abs (a[mx] + a[i] + a[my]), (mx, i, my))
|> List.minBy fst
|> snd
|> fun (x, i, y) -> printfn "%d %d %d" a[x] a[i] a[y]
