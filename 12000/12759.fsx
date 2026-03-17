let start = stdin.ReadLine() |> int

let row = Array2D.zeroCreate 3 4
let col = Array2D.zeroCreate 3 4
let crs = Array2D.zeroCreate 3 2

let _, result =
    Array.init 9 (fun _ -> stdin.ReadLine().Split() |> Array.map int)
    |> Array.fold
        (fun (turn, win) [| x; y |] ->
            if win = 0 then
                row[turn, x] <- row[turn, x] + 1
                col[turn, y] <- col[turn, y] + 1

                if x = y then
                    crs[turn, 0] <- crs[turn, 0] + 1

                if x + y = 4 then
                    crs[turn, 1] <- crs[turn, 1] + 1

                if
                    row[turn, x] = 3
                    || col[turn, y] = 3
                    || crs[turn, 0] = 3
                    || crs[turn, 1] = 3
                then
                    0, turn
                else
                    (if turn = 1 then 2 else 1), 0
            else
                turn, win)
        (start, 0)

printfn "%d" result
