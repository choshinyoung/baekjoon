open System
open System.Collections.Generic
open System.Linq

let n = stdin.ReadLine() |> int
let a = stdin.ReadLine().Split() |> Array.map int

let tails = List()
let parent = Array.create n -1

let lowerBound x =
    let rec search l r =
        if l > r then
            l
        else
            let m = (l + r) / 2

            if a[tails[m]] < x then
                search (m + 1) r
            else
                search l (m - 1)

    search 0 (tails.Count - 1)

for i in 0 .. n - 1 do
    let x = a[i]
    let index = lowerBound x

    if index = tails.Count then
        if tails.Count > 0 then
            parent[i] <- tails.Last()

        tails.Add i
    else
        if index > 0 then
            parent[i] <- tails[index - 1]

        tails[index] <- i

let rec trace i =
    if i = -1 then [] else a[i] :: trace parent[i]

let result = trace (tails.Last()) |> List.rev

printfn "%d" result.Length
String.Join(" ", result) |> printfn "%s"
