open System.Collections.Generic

let input () = stdin.ReadLine() |> int

let inputs () =
    stdin.ReadLine().Split() |> Array.map int64

let sum x =
    let n = Array.length x
    let result = Array.zeroCreate n

    result[0] <- x[0]

    for i in 1 .. n - 1 do
        result[i] <- result[i - 1] + x[i]

    result

let t = input () |> int64
let n, a = input (), inputs ()
let m, b = input (), inputs ()

let sumA = sum a
let sumB = sum b

let set = Dictionary()
let mutable result = 0L

for i in 0 .. n - 1 do
    for j in i .. n - 1 do
        let s = if i = 0 then sumA[j] else sumA[j] - sumA[i - 1]

        if set.ContainsKey s then
            set[s] <- set[s] + 1
        else
            set[s] <- 1

for i in 0 .. m - 1 do
    for j in i .. m - 1 do
        let sB = if i = 0 then sumB[j] else sumB[j] - sumB[i - 1]
        let sA = t - sB

        if set.ContainsKey sA then
            result <- result + int64 set[sA]

printfn "%d" result
