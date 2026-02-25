stdin.ReadLine() |> ignore

stdin.ReadLine().Split()
|> Array.sumBy (fun x -> if x = "1" then 1 else -1)
|> fun x -> if x >= 0 && x % 3 = 0 then "Yes" else "No"
|> printfn "%s"
