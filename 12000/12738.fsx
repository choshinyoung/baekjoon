open System.Collections.Generic
open System.Linq

stdin.ReadLine() |> ignore

let tails = List()

stdin.ReadLine().Split()
|> Array.map int
|> Array.iter (fun x ->
    if not (tails.Any()) || x > tails.Last() then
        tails.Add x
    else
        let index = tails.BinarySearch x

        if index >= 0 then
            tails[index] <- x
        else
            tails[~~~index] <- x)

printfn "%d" tails.Count
