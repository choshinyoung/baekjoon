open System

let T = stdin.ReadLine() |> int

for _ in 1..T do
    let n = stdin.ReadLine() |> int
    let size = stdin.ReadLine().Split() |> Array.map int
    let dp = Array2D.zeroCreate n n

    for len in 1 .. n - 1 do
        for i in 0 .. n - 1 - len do
            let j = i + len

            dp[i, j] <- Int32.MaxValue
            let sum = Seq.sum size[i..j]

            for k in i .. j - 1 do
                let cost = dp[i, k] + dp[k + 1, j] + sum
                dp[i, j] <- min dp[i, j] cost

    printfn "%A" dp[0, n - 1]
