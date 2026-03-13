let t = stdin.ReadLine() |> int

for _ in 1..t do
    let [| a; b |] = stdin.ReadLine().Split() |> Array.map float
    printfn "The height of the triangle is %.2f units" (a * 2.0 / b)
