open System

let [| c; n |] = Console.ReadLine().Split() |> Array.map int

let city =
    Array.init n (fun _ ->
        Console.ReadLine().Split()
        |> Array.map int
        |> fun x -> x[0], x[1])

let dp = Array.create (c + 101) (1000 * 100)
dp[0] <- 0

for v, w in city do
    for j in w .. (c + 100) do
        dp[j] <- min (dp[j]) (dp[j - w] + v)

dp |> Array.skip c |> Array.min |> printfn "%d"
