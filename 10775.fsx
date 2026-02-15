let input = stdin.ReadLine >> int

let g = input ()
let p = input ()
let planes = Array.init p (fun _ -> input ())

let parent = Array.init (g + 1) id

let rec find x =
    if parent[x] <> x then
        parent[x] <- find parent[x]

    parent[x]

let mutable result = 0

for i in 0 .. p - 1 do
    let root = find planes[i]

    if root = 0 then
        printfn "%d" result
        exit 0

    parent[root] <- find (root - 1)
    result <- result + 1

printfn "%d" result
