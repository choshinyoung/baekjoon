type Point = { x: int64; y: int64 }

let ccw p1 p2 p3 =
    (p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x) |> sign

let isIntersect a b c d =
    let abc = ccw a b c
    let abd = ccw a b d
    let cda = ccw c d a
    let cdb = ccw c d b

    if abc * abd = 0 && cda * cdb = 0 then
        let a', b' = if a <= b then a, b else b, a
        let c', d' = if c <= d then c, d else d, c

        c' <= b' && a' <= d'
    else
        abc * abd <= 0 && cda * cdb <= 0

let n = stdin.ReadLine() |> int

let points =
    Array.init n (fun _ ->
        match stdin.ReadLine().Split() |> Array.map int with
        | [| x1; y1; x2; y2 |] -> { x = x1; y = y1 }, { x = x2; y = y2 })

let parents = Array.init n id

let rec find a =
    if parents[a] <> a then
        parents[a] <- find parents[a]

    parents[a]

let union a b =
    let a' = find a
    let b' = find b

    if a' <> b' then
        parents[b'] <- a'

points
|> Array.iteri (fun i (a, b) ->
    points
    |> Array.iteri (fun j (c, d) ->
        if i < j then
            if isIntersect a b c d then
                union i j))

let result = [ 0 .. n - 1 ] |> List.map find |> List.countBy id

result |> List.length |> printfn "%d"
result |> List.maxBy snd |> snd |> printfn "%d"
