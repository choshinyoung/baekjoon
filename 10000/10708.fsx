let input () =
    stdin.ReadLine().Split() |> Array.map int

let n = stdin.ReadLine() |> int
let m = stdin.ReadLine() |> int

(input (), Seq.init m (fun _ -> input ()))
||> Seq.fold2
        (fun score a b ->
            let c = b |> Array.filter (fun x -> x <> a) |> Array.length

            score
            |> Array.mapi (fun i x ->
                if i = a - 1 then x + c + 1
                elif b[i] = a then x + 1
                else x))
        (Array.zeroCreate n)
|> Array.iter (printfn "%d")
