let m = stdin.ReadLine().Split()[1] |> int
let s = stdin.ReadLine()

let count = Array.zeroCreate 128

s
|> Seq.sort
|> Seq.take m
|> Seq.iter (fun c ->
    let i = int c
    count[i] <- count[i] + 1)

s
|> String.filter (fun c ->
    let i = int c

    if count[i] > 0 then
        count[i] <- count[i] - 1
        false
    else
        true)
|> printfn "%s"
