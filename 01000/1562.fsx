let n = stdin.ReadLine() |> int

let dp = Array3D.zeroCreate n 10 1024

for i in 1..9 do
    dp[0, i, 1 <<< i] <- 1

for len in 1 .. n - 1 do
    for i in 0..9 do
        for mask in 0..1023 do
            if dp[len - 1, i, mask] > 0 then
                let next i' =
                    let mask' = mask ||| (1 <<< i')

                    dp[len, i', mask'] <-
                        (dp[len, i', mask'] + dp[len - 1, i, mask]) % 1000000000

                if i > 0 then
                    next (i - 1)

                if i < 9 then
                    next (i + 1)

let result =
    [ 0..9 ]
    |> List.fold (fun acc x -> (acc + dp[n - 1, x, 1023]) % 1000000000) 0

printfn "%d" result
