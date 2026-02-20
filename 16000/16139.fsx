open System.Text

let char2int c = int c - int 'a'

let sum =
    stdin.ReadLine()
    |> Seq.toArray
    |> Array.scan
        (fun acc x ->
            let acc' = Array.copy acc

            let i = char2int x
            acc'[i] <- acc'[i] + 1

            acc')
        (Array.zeroCreate 26)

let q = stdin.ReadLine() |> int

let sb = StringBuilder()

for _ in 1..q do
    let a, l, r =
        match stdin.ReadLine().Split() with
        | [| x; y; z |] -> char x, int y, int z

    let j = char2int a
    sum[r + 1][j] - sum[l][j] |> string |> sb.AppendLine |> ignore

sb.ToString() |> printfn "%s"
