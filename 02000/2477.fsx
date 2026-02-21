let k = stdin.ReadLine() |> int

let a = Array.init 6 (fun _ -> stdin.ReadLine()[2..] |> int)
let p = Array.init 6 (fun i -> a[i] * a[(i + 1) % 6])

(Array.sum p - 2 * Array.max p) * k |> printfn "%d"
