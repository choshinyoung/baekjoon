match stdin.ReadLine() |> int with
| x when x < 6 -> "Oh My God!"
| _ -> "Success!"
|> printfn "%s"
