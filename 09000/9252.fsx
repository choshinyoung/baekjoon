let s1 = stdin.ReadLine()
let s2 = stdin.ReadLine()

let n1 = s1.Length
let n2 = s2.Length

let dp = Array2D.zeroCreate n1 n2

let getDp (i, j) = if i < 0 || j < 0 then 0 else dp[i, j]

for i in 0 .. n1 - 1 do
    for j in 0 .. n2 - 1 do
        if s1[i] = s2[j] then
            dp[i, j] <- getDp (i - 1, j - 1) + 1
        else
            dp[i, j] <- max (getDp (i - 1, j)) (getDp (i, j - 1))

printfn "%d" dp[n1 - 1, n2 - 1]

let rec trace (i, j) =
    if i < 0 || j < 0 then []
    elif s1[i] = s2[j] then trace (i - 1, j - 1) @ [ s1[i] ]
    else [ i - 1, j; i, j - 1 ] |> List.maxBy getDp |> trace

trace (n1 - 1, n2 - 1)
|> List.map string
|> String.concat ""
|> printfn "%s"
