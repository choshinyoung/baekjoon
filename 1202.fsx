open System.Collections.Generic

let input () =
    stdin.ReadLine().Split() |> Array.map int

let [| n; k |] = input ()

let mv =
    Array.init n (fun _ ->
        match input () with
        | [| m; v |] -> m, v)
    |> Array.sort

let c = Array.init k (fun _ -> stdin.ReadLine() |> int) |> Array.sort

let pq = PriorityQueue<int, int>()
let mutable result = 0L
let mutable j = 0

for bag in c do
    while j < n && fst mv[j] <= bag do
        let v = snd mv[j]
        pq.Enqueue(v, -v)

        j <- j + 1

    if pq.Count > 0 then
        result <- result + int64 (pq.Dequeue())

printfn "%d" result
