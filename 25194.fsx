open System

Console.ReadLine() |> ignore
let A = Console.ReadLine().Split() |> Array.map int

let mutable dp = Array.create 7 false
dp[0] <- true

for a in A do
    let dp' = Array.copy dp

    for i in 0..6 do
        if dp[i] then
            dp'[(i + a) % 7] <- true

    dp <- dp'

if dp[4] then "YES" else "NO"
|> printfn "%s"
