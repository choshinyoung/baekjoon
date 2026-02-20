open System

let count = stdin.ReadLine() |> Seq.countBy id |> Seq.sort |> Seq.toList
let odds = count |> List.filter (fun (_, n) -> n % 2 = 1)

if odds.Length > 1 then
    printfn "I'm Sorry Hansoo"
else
    let left =
        count
        |> List.map (fun (c, n) -> String(c, n / 2))
        |> String.concat ""

    let mid = if odds.Length = 1 then fst odds[0] |> string else ""

    let right = left |> Seq.rev |> Seq.toArray |> String

    printfn "%s%s%s" left mid right
