open System
open System.Collections.Generic

let toNum c =
    match c with
    | _ when Char.IsLower c -> int c - int 'a'
    | _ when Char.IsUpper c -> int c - int 'A'
    | _ -> -1

let t = stdin.ReadLine() |> int

for _ in 1..t do
    let [| h; w |] = stdin.ReadLine().Split() |> Array.map int

    let doors = Array.init 26 (fun _ -> [])
    let visited = Array.init h (fun _ -> Array.create w false)
    let keys = Array.zeroCreate 26
    let queue = Queue<int * int>()

    let map = Array.init h (fun _ -> stdin.ReadLine() |> Seq.toArray)

    stdin.ReadLine()
    |> Seq.map toNum
    |> Seq.filter (fun x -> x <> -1)
    |> Seq.iter (fun x -> keys[x] <- true)

    let mutable result = 0

    let enqueue y x =
        let block = map[y][x]
        let key = toNum block

        if block = '.' then
            queue.Enqueue(y, x)
            visited[y][x] <- true
        elif block = '$' then
            result <- result + 1
            queue.Enqueue(y, x)
            visited[y][x] <- true
        elif Char.IsUpper block then
            if keys[key] then
                queue.Enqueue(y, x)
                visited[y][x] <- true
            else
                doors[key] <- (y, x) :: doors[key]
        elif Char.IsLower block then
            keys[key] <- true
            doors[key] |> List.iter queue.Enqueue

            queue.Enqueue(y, x)
            visited[y][x] <- true

    for y in 0 .. h - 1 do
        enqueue y 0
        enqueue y (w - 1)

    for x in 1 .. w - 2 do
        enqueue 0 x
        enqueue (h - 1) x

    while queue.Count > 0 do
        let y, x = queue.Dequeue()

        [ y - 1, x; y + 1, x; y, x - 1; y, x + 1 ]
        |> List.iter (fun (y', x') ->
            if
                y' >= 0
                && y' < h
                && x' >= 0
                && x' < w
                && not (visited[y'][x'])
            then
                enqueue y' x')

    printfn "%d" result
