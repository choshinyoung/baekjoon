let (*) s a = String.replicate a s

let n = stdin.ReadLine() |> int

if n % 2 = 0 then
    printfn "I LOVE CBNU"
else
    printfn "%s\n%s*" ("*" * n) (" " * (n / 2))

    for i in 1 .. n / 2 do
        printfn "%s*%s*" (" " * (n / 2 - i)) (" " * (i + i - 1))
