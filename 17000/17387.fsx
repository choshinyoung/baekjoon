let [| x1; y1; x2; y2 |] = stdin.ReadLine().Split() |> Array.map int64
let [| x3; y3; x4; y4 |] = stdin.ReadLine().Split() |> Array.map int64

let ccw x1 y1 x2 y2 x3 y3 =
    compare (x1 * y2 + x2 * y3 + x3 * y1) (y1 * x2 + y2 * x3 + y3 * x1)

let a = ccw x1 y1 x2 y2 x3 y3 * ccw x1 y1 x2 y2 x4 y4
let b = ccw x3 y3 x4 y4 x1 y1 * ccw x3 y3 x4 y4 x2 y2

if a = 0 && b = 0 then
    let p1, p2 = min (x1, y1) (x2, y2), max (x1, y1) (x2, y2)
    let p3, p4 = min (x3, y3) (x4, y4), max (x3, y3) (x4, y4)

    if p1 <= p4 && p3 <= p2 then printfn "1" else printfn "0"
elif a <= 0 && b <= 0 then
    printfn "1"
else
    printfn "0"
