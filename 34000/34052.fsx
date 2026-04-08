let a = Seq.init 4 (fun _ -> stdin.ReadLine() |> int) |> Seq.sum

if a + 300 <= 1800 then "Yes" else "No"
|> printfn "%s"
