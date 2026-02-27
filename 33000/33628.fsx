// 솔직히 이해 못 함
open System.Text

let [| n; q |] = stdin.ReadLine().Split() |> Array.map int

let adj = Array.init (n + 1) (fun _ -> ResizeArray())
let parents = Array2D.zeroCreate (n + 1) 21
let depths = Array.zeroCreate (n + 1)

let ufParent = Array.init (n + 1) id
let ufSize = Array.create (n + 1) 1
let ufMin = Array.init (n + 1) id

let rec find x =
    if ufParent[x] = x then
        x
    else
        ufParent[x] <- find ufParent[x]
        ufParent[x]

let rec dfs curr p =
    depths[curr] <- depths[p] + 1
    parents[curr, 0] <- p

    for i in 1..20 do
        parents[curr, i] <- parents[parents[curr, i - 1], i - 1]

    for next in adj[curr] do
        if next <> p then
            dfs next curr

let rec matchDepth a b i =
    if i < 0 then
        b
    elif depths[b] - depths[a] >= (1 <<< i) then
        matchDepth a parents[b, i] (i - 1)
    else
        matchDepth a b (i - 1)

let rec findAncestor a b i =
    if i < 0 then
        parents[a, 0]
    elif parents[a, i] <> parents[b, i] then
        findAncestor parents[a, i] parents[b, i] (i - 1)
    else
        findAncestor a b (i - 1)

let lca u v =
    let a, b =
        (if depths[u] < depths[v] then u, v else v, u)
        |> fun (x, y) -> x, matchDepth x y 20

    if a = b then a else findAncestor a b 20

let mutable lastAns = 0
let output = StringBuilder()

for _ in 1..q do
    let t, a, b =
        stdin.ReadLine().Split()
        |> fun [| t; x; y |] ->
            t = "1", int x ^^^ lastAns, int y ^^^ lastAns

    let rootA = find a
    let rootB = find b

    if t then
        if rootA <> rootB then
            let smallRoot, bigRoot, smallNode, bigNode =
                if ufSize[rootA] < ufSize[rootB] then
                    rootA, rootB, a, b
                else
                    rootB, rootA, b, a

            adj[smallNode].Add bigNode
            adj[bigNode].Add smallNode

            ufParent[smallRoot] <- bigRoot
            ufSize[bigRoot] <- ufSize[bigRoot] + ufSize[smallRoot]
            ufMin[bigRoot] <- min ufMin[bigRoot] ufMin[smallRoot]

            dfs smallNode bigNode
    else if rootA <> rootB then
        lastAns <- 0
        output.AppendLine "0" |> ignore
    else
        let m = ufMin[rootA]

        let x = lca a b
        let y = lca b m
        let z = lca m a

        let ans = x ^^^ y ^^^ z
        lastAns <- ans
        ans |> string |> output.AppendLine |> ignore

output.ToString() |> printfn "%s"
