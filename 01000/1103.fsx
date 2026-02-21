let [| n; m |] = stdin.ReadLine().Split() |> Array.map int

let board = Array.init n (fun _ -> stdin.ReadLine())
let memo = Array2D.zeroCreate n m

let rec dfs y x =
    if x < 0 || y < 0 || x >= m || y >= n || board[y][x] = 'H' then
        0
    elif memo[y, x] = -1 then
        -1
    elif memo[y, x] <> 0 then
        memo[y, x]
    else
        memo[y, x] <- -1

        let d = int (board[y][x]) - int '0'

        let next =
            [ dfs y (x + d); dfs y (x - d); dfs (y - d) x; dfs (y + d) x ]

        if List.forall (fun x -> x >= 0) next then
            memo[y, x] <- (List.max next) + 1

        memo[y, x]

dfs 0 0 |> printfn "%d"
