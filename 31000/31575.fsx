let [| n; m |] = stdin.ReadLine().Split() |> Array.map int

let city =
    Array.init m (fun _ ->
        stdin.ReadLine().Split() |> Array.map (fun x -> x = "1"))

let visited = Array2D.zeroCreate m n

let rec dfs (y, x) =
    if
        y < 0
        || x < 0
        || y >= m
        || x >= n
        || not (city[y][x])
        || visited[y, x]
    then
        false
    elif y = m - 1 && x = n - 1 then
        true
    else
        visited[y, x] <- true
        [ y + 1, x; y, x + 1 ] |> List.exists dfs

if dfs (0, 0) then printfn "Yes" else printfn "No"
