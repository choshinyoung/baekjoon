open System

let MAX = 1000 * 1000

let N = Console.ReadLine() |> int

let RGB =
    Array.init N (fun _ -> Console.ReadLine().Split() |> Array.map int)

[ 0..2 ]
|> List.map (fun f ->
    let dp = Array.init N (fun _ -> Array.create 3 MAX)
    dp[0][f] <- RGB[0][f]

    for i in 1 .. (N - 1) do
        dp[i][0] <- RGB[i][0] + min (dp[i - 1][1]) (dp[i - 1][2])
        dp[i][1] <- RGB[i][1] + min (dp[i - 1][0]) (dp[i - 1][2])
        dp[i][2] <- RGB[i][2] + min (dp[i - 1][0]) (dp[i - 1][1])

    dp[N - 1] |> Array.removeAt f |> Array.min)
|> List.min
|> printfn "%d"
