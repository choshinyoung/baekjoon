let n = stdin.ReadLine() |> int

if n = 0 then
    printfn "divide by zero"
else
    let a = stdin.ReadLine().Split() |> Array.map double
    let e = Array.sumBy (fun x -> x / double n) a

    if e = 0 then
        printfn "divide by zero"
    else
        Array.average a / e |> printfn "%.2f"
