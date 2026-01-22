open System

let n = stdin.ReadLine() |> int

let m =
    Array.init n (fun _ ->
        stdin.ReadLine().Split() |> Array.map int |> (fun x -> x[0], x[1]))

let dp = Array2D.zeroCreate n n

for len in 1 .. n - 1 do
    for i in 0 .. n - 1 - len do
        let j = i + len
        dp[i, j] <- Int32.MaxValue

        for k in i .. j - 1 do
            let cost =
                dp[i, k] + dp[k + 1, j] + fst m[i] * snd m[k] * snd m[j]

            dp[i, j] <- min dp[i, j] cost

printfn "%d" dp[0, n - 1]
