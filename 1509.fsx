let s = stdin.ReadLine()
let n = s.Length

let TAT = Array2D.zeroCreate (n + 1) n

for i in 0 .. n - 1 do
    TAT[1, i] <- true

for i in 0 .. n - 2 do
    TAT[2, i] <- s[i] = s[i + 1]

for len in 3..n do
    for i in 0 .. n - len do
        let j = i + len - 1

        TAT[len, i] <- TAT[len - 2, i + 1] && s[i] = s[j]

let div = Array.init n (fun x -> x + 1)

for j in 1 .. n - 1 do
    for i in 0..j do
        let len = j - i + 1

        if TAT[len, i] then
            let m = if i = 0 then 1 else div[i - 1] + 1

            div[j] <- min div[j] m

printfn "%d" div[n - 1]
