let n = stdin.ReadLine() |> int
let mutable s = set []

Seq.init n (fun _ -> stdin.ReadLine().Split() |> Array.map int)
|> Seq.exists (fun t ->
    if Seq.exists s.Contains t then
        true
    else
        s <- s + set t
        false)
|> function true -> 1 | _ -> 0
|> printf "%d"
