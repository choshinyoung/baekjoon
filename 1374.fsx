open System.Collections.Generic

let pq = PriorityQueue()
let room = PriorityQueue()

let n = stdin.ReadLine() |> int

for _ in 1..n do
    let [| _; s; e |] = stdin.ReadLine().Split() |> Array.map int
    pq.Enqueue((s, e), (s, e))

while pq.Count > 0 do
    let s, e = pq.Dequeue()

    if room.Count > 0 && room.Peek() <= s then
        room.Dequeue() |> ignore

    room.Enqueue(e, e)

printfn "%d" room.Count
