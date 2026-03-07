let input () =
    stdin.ReadLine().Split() |> Array.map int

let [| n; m; k |] = input ()
let c = input ()

let parents = Array.init (n + 1) id
let dp = Array.zeroCreate k

let rec find a =
    if parents[a] = a then
        a
    else
        parents[a] <- find parents[a]
        parents[a]

let union a b =
    let a' = find a
    let b' = find b

    if a' <> b' then
        parents[b'] <- a'

for _ in 1..m do
    let [| a; b |] = input ()
    union a b

[ 1..n ]
|> List.groupBy find
|> List.map (fun (_, a) -> a |> List.sumBy (fun x -> c[x - 1]), a.Length)
|> List.iter (fun (w, s) ->
    for i in k - 1 .. -1 .. s do
        dp[i] <- max dp[i] (dp[i - s] + w))

printfn "%d" dp[k - 1]
