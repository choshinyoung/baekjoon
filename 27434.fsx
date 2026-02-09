open System.Numerics

let rec fac a b =
    if a >= b then
        a
    else
        let m = (a + b) / 2I
        fac a m * fac (m + 1I) b

let n = stdin.ReadLine() |> int |> bigint
fac 1I n |> printfn "%A"
