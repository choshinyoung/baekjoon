open System.Collections.Generic

let n = stdin.ReadLine() |> int
let s = Array.init n (fun _ -> stdin.ReadLine())

[ 1 .. s[0].Length ]
|> List.find (fun k ->
    let set = HashSet()
    s |> Array.forall (fun x -> set.Add x[x.Length - k ..]))
|> printfn "%d"
