open System

let N = Console.ReadLine() |> int
let A = Console.ReadLine().Split() |> Array.map int

let rec search x y a b =
    if x >= y then
        printfn "%d %d" A[a] A[b]
    else
        let m = A[a] + A[b]
        let p = A[x] + A[y]

        let a', b' = if abs m < abs p then a, b else x, y
        let x', y' = if p > 0 then x, y - 1 else x + 1, y

        search x' y' a' b'

let x, y = 0, N - 1
search x y x y
