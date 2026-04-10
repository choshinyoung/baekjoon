let n = stdin.ReadLine() |> int

let b1, b2 =
    [| 1..n |]
    |> Array.collect (fun i ->
        stdin.ReadLine().Split() |> Array.mapi (fun j x -> i, j, x = "1"))
    |> Array.choose (fun (i, j, x) -> if x then Some(i, j) else None)
    |> Array.partition (fun (i, j) -> (i + j) % 2 = 0)

let usedL = Array.create (n * 2) false
let usedR = Array.create (n * 2) false

let rec solve count i (b: (int * int)[]) =
    if i = b.Length then
        count
    else
        let r, c = b[i]
        let mx = solve count (i + 1) b

        if usedL[r + c] || usedR[r - c + n - 1] then
            mx
        else
            usedL[r + c] <- true
            usedR[r - c + n - 1] <- true

            let mx' = max mx (solve (count + 1) (i + 1) b)

            usedL[r + c] <- false
            usedR[r - c + n - 1] <- false

            mx'

printfn "%d" (solve 0 0 b1 + solve 0 0 b2)
