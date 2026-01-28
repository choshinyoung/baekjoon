let [| x1; y1; x2; y2 |] = stdin.ReadLine().Split() |> Array.map int64
let [| x3; y3; x4; y4 |] = stdin.ReadLine().Split() |> Array.map int64

let ccw x1 y1 x2 y2 x3 y3 =
    compare (x1 * y2 + x2 * y3 + x3 * y1) (y1 * x2 + y2 * x3 + y3 * x1)

let a = ccw x1 y1 x2 y2 x3 y3 * ccw x1 y1 x2 y2 x4 y4
let b = ccw x3 y3 x4 y4 x1 y1 * ccw x3 y3 x4 y4 x2 y2

printfn (if a < 0 && b < 0 then "1" else "0")
