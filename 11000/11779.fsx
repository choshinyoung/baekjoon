open System
open System.Collections.Generic

let n = Console.ReadLine() |> int
let m = Console.ReadLine() |> int

let vertexes = Array.init (n + 1) (fun _ -> [])

for _ in 1..m do
    let [| s; e; x |] = Console.ReadLine().Split() |> Array.map int

    vertexes[s] <- (e, x) :: vertexes[s]

let [| s; e |] = Console.ReadLine().Split() |> Array.map int

let dist = Array.create (n + 1) (Int32.MaxValue, 0)
dist[s] <- 0, 0

let queue = PriorityQueue<int, int>()
queue.Enqueue(s, 0)

while queue.Count > 0 do
    let s' = queue.Dequeue()

    for e', x in vertexes[s'] do
        if fst dist[e'] > fst dist[s'] + x then
            dist[e'] <- fst dist[s'] + x, s'
            queue.Enqueue(e', fst dist[e'])

let rec trace e =
    if e = 0 then [] else e :: trace (snd dist[e])

let route = e |> trace |> List.rev

printfn
    "%d\n%d\n%s"
    (fst dist[e])
    (List.length route)
    (String.Join(" ", route |> List.map string |> List.toArray))
