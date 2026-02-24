let n = stdin.ReadLine() |> int

let io = stdin.ReadLine().Split() |> Array.map int
let po = stdin.ReadLine().Split() |> Array.map int

let index = io |> Array.indexed |> Array.sortBy snd |> Array.map fst

let rec solve i p n =
    if n = 0 then
        ()
    elif n = 1 then
        io[i] |> printf "%d "
    else
        let mid = po[p + n - 1]
        printf "%d " mid

        let n'l = index[mid - 1] - i
        solve i p n'l

        let n'r = n - n'l - 1
        solve (index[mid - 1] + 1) (p + n'l) n'r

solve 0 0 n
