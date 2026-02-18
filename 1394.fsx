let a = stdin.ReadLine()
let b = stdin.ReadLine()

let n = a.Length

let index = a |> Seq.mapi (fun i x -> x, i + 1) |> dict
let result = b |> Seq.fold (fun acc c -> (acc * n + index[c]) % 900528) 0

printfn "%d" result
