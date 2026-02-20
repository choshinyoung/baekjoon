stdin.ReadLine()
|> String.collect (fun c ->
    [| "000"; "001"; "010"; "011"; "100"; "101"; "110"; "111" |][int c - int '0'])
|> fun x -> x.TrimStart '0'
|> fun x -> if x = "" then "0" else x
|> printf "%s"
