let input () = stdin.ReadLine() |> int

for _ in 1 .. input () do
    input ()
    + (Array.init (input ()) (fun _ ->
        stdin.ReadLine().Split() |> fun [| p; q |] -> int p * int q)
       |> Array.sum)
    |> printfn "%d"
