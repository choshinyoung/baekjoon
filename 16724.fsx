open System

let [| n; m |] = Console.ReadLine().Split() |> Array.map int
let map = Array.init n (fun _ -> Console.ReadLine())

let parents = Array.init n (fun i -> Array.init m (fun j -> i, j))
let visited = Array.init n (fun _ -> Array.zeroCreate m)

let rec find (y, x) =
    if parents[y][x] = (y, x) then
        y, x
    else
        parents[y][x] <- find (parents[y][x])
        parents[y][x]

let rec dfs (y, x) =
    if not (visited[y][x]) then
        visited[y][x] <- true

        let next =
            match map[y][x] with
            | 'U' -> y - 1, x
            | 'D' -> y + 1, x
            | 'L' -> y, x - 1
            | 'R' -> y, x + 1

        let aY, aX = find (y, x)
        let bY, bX = find next
        parents[bY][bX] <- parents[aY][aX]

        dfs next

for y in 0 .. n - 1 do
    for x in 0 .. m - 1 do
        dfs (y, x)

[ for y in 0 .. n - 1 do
      for x in 0 .. m - 1 do
          find (y, x) ]
|> List.distinct
|> List.length
|> printfn "%d"
