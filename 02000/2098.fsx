open System

let n = stdin.ReadLine() |> int
let w = Array.init n (fun _ -> stdin.ReadLine().Split() |> Array.map int)

let dp = Array2D.create n (1 <<< 16) -1

let rec dfs i visited =
    if visited = (1 <<< n) - 1 then
        if w[i][0] = 0 then Int32.MaxValue else w[i][0]
    elif dp[i, visited] <> -1 then
        dp[i, visited]
    else
        dp[i, visited] <- Int32.MaxValue

        for j in 0 .. n - 1 do
            let visited' = 1 <<< j

            if w[i][j] <> 0 && visited &&& visited' = 0 then
                let cost = dfs j (visited ||| visited')

                if cost <> Int32.MaxValue then
                    dp[i, visited] <- min dp[i, visited] (w[i][j] + cost)

        dp[i, visited]

dfs 0 1 |> printfn "%d"
