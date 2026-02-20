let txt = stdin.ReadLine()
let key = stdin.ReadLine()

txt
|> String.mapi (fun i c ->
    match c with
    | ' ' -> ' '
    | _ -> char ((int c - int key[i % key.Length] + 25) % 26 + int 'a'))
|> printfn "%s"
