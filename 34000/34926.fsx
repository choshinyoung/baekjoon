open System.Collections.Generic

let [| n; k |] = stdin.ReadLine().Split() |> Array.map int
let m = stdin.ReadLine() |> Seq.map (fun x -> x = '_') |> Seq.toArray

let queue = Queue()
queue.Enqueue 0

let visited = Array.zeroCreate n

while queue.Count > 0 do
    let a = queue.Dequeue()

    if a = n - 1 then
        printfn "YES"
        exit 0

    if a < n && m[a] && not visited[a] then
        visited[a] <- true

        queue.Enqueue(a + 1)
        queue.Enqueue(a + k)

printfn "NO"
