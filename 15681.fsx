open System
open System.Text

let [| N; R; Q |] = Console.ReadLine().Split() |> Array.map int

let connect = Array.init (N + 1) (fun _ -> [])
let child = Array.init (N + 1) (fun _ -> [])
let size = Array.create (N + 1) 0

for _ in 2..N do
    let [| U; V |] = Console.ReadLine().Split() |> Array.map int

    connect[U] <- V :: connect[U]
    connect[V] <- U :: connect[V]

let rec makeTree currentNode parent =
    for node in connect[currentNode] do
        if node <> parent then
            child[currentNode] <- node :: child[currentNode]
            makeTree node currentNode

let rec countSubtreeNodes currentNode =
    size[currentNode] <- 1

    for node in child[currentNode] do
        countSubtreeNodes node
        size[currentNode] <- size[currentNode] + size[node]

makeTree R 0
countSubtreeNodes R

let sb = StringBuilder()

for _ in 1..Q do
    let U = Console.ReadLine() |> int
    sb.AppendLine(string (size[U])) |> ignore

sb.ToString() |> printfn "%s"
