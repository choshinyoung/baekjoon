let INF = 400001

let a =
    stdin.ReadLine().Split()
    |> Array.map int
    |> Array.takeWhile (fun x -> x <> 0)

let dp = Array.init a.Length (fun _ -> Array2D.create 5 5 INF)

let getCost a b =
    if a = 0 then 2
    elif a = b then 1
    elif abs (a - b) = 2 then 4
    else 3

a
|> Array.iteri (fun i x ->
    if i = 0 then
        dp[i][x, 0] <- 2
        dp[i][0, x] <- 2
    else
        for l in 0..4 do
            for r in 0..4 do
                if dp[i - 1][l, r] <> INF then
                    if x <> r then
                        dp[i][x, r] <-
                            min
                                (dp[i][x, r])
                                (dp[i - 1][l, r] + getCost l x)

                    if x <> l then
                        dp[i][l, x] <-
                            min
                                (dp[i][l, x])
                                (dp[i - 1][l, r] + getCost x r))

[ 0..4 ]
|> List.map (fun l ->
    [ 0..4 ] |> List.map (fun r -> dp[a.Length - 1][l, r]) |> List.min)
|> List.min
|> printfn "%d"
