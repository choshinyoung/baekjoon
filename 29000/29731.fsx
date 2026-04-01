let n = stdin.ReadLine() |> int

Array.init n (fun _ -> stdin.ReadLine())
|> Array.exists (fun x ->
    match x with
    | "Never gonna give you up"
    | "Never gonna let you down"
    | "Never gonna run around and desert you"
    | "Never gonna make you cry"
    | "Never gonna say goodbye"
    | "Never gonna tell a lie and hurt you"
    | "Never gonna stop" -> false
    | _ -> true)
|> fun x -> if x then "Yes" else "No"
|> printfn "%s"
