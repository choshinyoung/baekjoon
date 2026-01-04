open System
open System.Collections.Generic

let N = Console.ReadLine() |> int

let map =
    Array.init N (fun _ ->
        Console.ReadLine().Split() |> Array.map int)

let mutable size = 2
let mutable stack = 0
let mutable result = 0

let queue = PriorityQueue<int * int * int, int * int * int>()
let visited = Array.init N (fun _ -> Array.create N false)

for y in 0 .. (N - 1) do
    for x in 0 .. (N - 1) do
        if map[y][x] = 9 then
            queue.Enqueue((x, y, 0), (0, y, x))
            map[y][x] <- 0
            visited[y][x] <- true

while queue.Count > 0 do
    let x, y, d = queue.Dequeue()

    if map[y][x] > 0 && map[y][x] < size then
        map[y][x] <- 0

        result <- d
        stack <- stack + 1

        if stack = size then
            size <- size + 1
            stack <- 0

        queue.Clear()
        queue.Enqueue((x, y, d), (d, y, x))

        for i in 0 .. (N - 1) do
            for j in 0 .. (N - 1) do
                visited[i][j] <- false

        visited[y][x] <- true

    if
        x > 0 && map[y][x - 1] <= size && not (visited[y][x - 1])
    then
        queue.Enqueue((x - 1, y, d + 1), (d + 1, y, x - 1))
        visited[y][x - 1] <- true

    if
        x < N - 1
        && map[y][x + 1] <= size
        && not (visited[y][x + 1])
    then
        queue.Enqueue((x + 1, y, d + 1), (d + 1, y, x + 1))
        visited[y][x + 1] <- true

    if
        y > 0 && map[y - 1][x] <= size && not (visited[y - 1][x])
    then
        queue.Enqueue((x, y - 1, d + 1), (d + 1, y - 1, x))
        visited[y - 1][x] <- true

    if
        y < N - 1
        && map[y + 1][x] <= size
        && not (visited[y + 1][x])
    then
        queue.Enqueue((x, y + 1, d + 1), (d + 1, y + 1, x))
        visited[y + 1][x] <- true

printfn "%d" result
