let [| a; b; c; d |] = Array.init 4 (fun _ -> stdin.ReadLine() |> int)

if (a = 8 || a = 9) && (d = 8 || d = 9) && b = c then
    printfn "ignore"
else
    printfn "answer"
