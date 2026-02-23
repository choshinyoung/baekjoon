open System.Collections.Generic

let [| n; m |] = stdin.ReadLine().Split() |> Array.map int

let k =
    Array.init n (fun _ ->
        stdin.ReadLine() |> Seq.map (fun x -> x = '1') |> Seq.toArray)

let group = Array2D.create n m -1
let size = List()

let verify y x = y >= 0 && x >= 0 && y < n && x < m

let rec dfs g (y, x) =
    if verify y x && not (k[y][x]) && group[y, x] = -1 then
        group[y, x] <- g

        [ y - 1, x; y + 1, x; y, x - 1; y, x + 1 ]
        |> List.map (dfs g)
        |> List.sum
        |> (+) 1
    else
        0

for y in 0 .. n - 1 do
    for x in 0 .. m - 1 do
        if not (k[y][x]) && group[y, x] = -1 then
            let i = size.Count

            dfs i (y, x) |> size.Add

[ 0 .. n - 1 ]
|> List.map (fun y ->
    [ 0 .. m - 1 ]
    |> List.map (fun x ->
        if not (k[y][x]) then
            "0"
        else
            let a =
                [ y - 1, x; y + 1, x; y, x - 1; y, x + 1 ]
                |> List.filter (fun (y, x) ->
                    verify y x && not (k[y][x]))
                |> List.map (fun (y, x) -> group[y, x])
                |> List.distinct
                |> List.map (fun x -> size[x])
                |> List.sum

            (a + 1) % 10 |> string)
    |> String.concat "")
|> String.concat "\n"
|> printfn "%s"
