open System.Collections.Generic

let [| a; k |] = stdin.ReadLine().Split() |> Array.map int

let queue = Queue()
queue.Enqueue(a, 0)

let visited = Array.zeroCreate k

while queue.Peek() |> fst <> k do
    let a', i = queue.Dequeue()

    if a' < k && not visited[a'] then
        visited[a'] <- true
        queue.Enqueue(a' + 1, i + 1)
        queue.Enqueue(a' * 2, i + 1)

queue.Peek() |> snd |> printfn "%d"
