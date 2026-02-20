open System.Collections.Generic

let [| n; m |] = stdin.ReadLine().Split() |> Array.map int

let tiles = Array2D.create n m '.'

let mutable hole = 0, 0
let mutable red = 0, 0
let mutable blue = 0, 0

for i in 0 .. n - 1 do
    stdin.ReadLine()
    |> Seq.iteri (fun j x ->
        match x with
        | 'O' -> hole <- i, j
        | 'R' -> red <- i, j
        | 'B' -> blue <- i, j
        | _ -> tiles[i, j] <- x)

let left red blue depth =
    let mutable red' = red
    let mutable blue' = blue

    let mutable escaped = ' '

    for y in 1 .. n - 2 do
        let mutable x' = 1

        for x in 1 .. m - 2 do
            let pos = y, x

            if pos = red then
                red' <- y, x'

                if
                    fst hole = y
                    && x' <= snd hole
                    && snd hole <= x
                    && escaped <> 'B'
                then
                    escaped <- 'R'
                else
                    x' <- x' + 1
            elif pos = blue then
                blue' <- y, x'

                if fst hole = y && x' <= snd hole && snd hole <= x then
                    escaped <- 'B'

                x' <- x' + 1
            elif tiles[y, x] = '#' then
                x' <- x + 1

    red',
    blue',
    (match escaped with
     | 'R' -> depth
     | 'B' -> -1
     | _ -> 0)

let right red blue depth =
    let mutable red' = red
    let mutable blue' = blue

    let mutable escaped = ' '

    for y in 1 .. n - 2 do
        let mutable x' = m - 2

        for x in m - 2 .. -1 .. 1 do
            let pos = y, x

            if pos = red then
                red' <- y, x'

                if
                    fst hole = y
                    && x <= snd hole
                    && snd hole <= x'
                    && escaped <> 'B'
                then
                    escaped <- 'R'
                else
                    x' <- x' - 1
            elif pos = blue then
                blue' <- y, x'

                if fst hole = y && x <= snd hole && snd hole <= x' then
                    escaped <- 'B'

                x' <- x' - 1
            elif tiles[y, x] = '#' then
                x' <- x - 1

    red',
    blue',
    (match escaped with
     | 'R' -> depth
     | 'B' -> -1
     | _ -> 0)

let up red blue depth =
    let mutable red' = red
    let mutable blue' = blue

    let mutable escaped = ' '

    for x in 1 .. m - 2 do
        let mutable y' = 1

        for y in 1 .. n - 2 do
            let pos = y, x

            if pos = red then
                red' <- y', x

                if
                    snd hole = x
                    && y' <= fst hole
                    && fst hole <= y
                    && escaped <> 'B'
                then
                    escaped <- 'R'
                else
                    y' <- y' + 1
            elif pos = blue then
                blue' <- y', x

                if snd hole = x && y' <= fst hole && fst hole <= y then
                    escaped <- 'B'

                y' <- y' + 1
            elif tiles[y, x] = '#' then
                y' <- y + 1

    red',
    blue',
    (match escaped with
     | 'R' -> depth
     | 'B' -> -1
     | _ -> 0)

let down red blue depth =
    let mutable red' = red
    let mutable blue' = blue

    let mutable escaped = ' '

    for x in 1 .. m - 2 do
        let mutable y' = n - 2

        for y in n - 2 .. -1 .. 1 do
            let pos = y, x

            if pos = red then
                red' <- y', x

                if
                    snd hole = x
                    && y <= fst hole
                    && fst hole <= y'
                    && escaped <> 'B'
                then
                    escaped <- 'R'
                else
                    y' <- y' - 1
            elif pos = blue then
                blue' <- y', x

                if snd hole = x && y <= fst hole && fst hole <= y' then
                    escaped <- 'B'

                y' <- y' - 1
            elif tiles[y, x] = '#' then
                y' <- y - 1

    red',
    blue',
    (match escaped with
     | 'R' -> depth
     | 'B' -> -1
     | _ -> 0)

let queue = Queue()
let visited = HashSet()

queue.Enqueue(red, blue, 1)
visited.Add(red, blue)

while queue.Count > 0 do
    let red, blue, depth = queue.Dequeue()

    if depth <= 10 then
        [ left; right; up; down ]
        |> List.iter (fun f ->
            let red', blue', result = f red blue depth

            if result > 0 then
                printfn "%d" result
                exit 0
            elif result = 0 then
                if visited.Add(red', blue') then
                    queue.Enqueue(red', blue', depth + 1))

printfn "-1"
