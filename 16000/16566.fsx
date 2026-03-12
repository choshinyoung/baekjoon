open System

let input () =
    stdin.ReadLine().Split() |> Array.map int

let [| _; m; _ |] = input ()
let cards = input () |> Array.sort
let cheol = input ()

let parents = Array.init (m + 1) id

let rec find a =
    if parents[a] = a then
        a
    else
        parents[a] <- find parents[a]
        parents[a]

let union a b =
    let a' = find a
    let b' = find b

    parents[a'] <- b'

let upperBound a =
    let i = Array.BinarySearch(cards, a + 1)
    if i >= 0 then i else ~~~i

for c in cheol do
    let a = upperBound c |> find
    printfn "%d" cards[a]

    union a (a + 1)
