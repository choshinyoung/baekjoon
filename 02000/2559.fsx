let input () =
    stdin.ReadLine().Split() |> Array.map int

let [| n; k |], a = input (), input ()

let rec solve i v m =
    if i + k > n then
        m
    else
        let v' = v - a[i - 1] + a[i + k - 1]
        let m' = max m v'

        solve (i + 1) v' m'

let v = Array.sum a[.. k - 1]
let result = solve 1 v v

printfn "%d" result
