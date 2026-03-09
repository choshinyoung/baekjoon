let n = stdin.ReadLine() |> int

for _ in 1..n do
    let m = stdin.ReadLine() |> int

    let square =
        Array.init m (fun _ -> stdin.ReadLine().Split() |> Array.map int)

    let isMagic =
        [ [ 0 .. m - 1 ]
          |> List.map (fun x ->
              [ 0 .. m - 1 ] |> List.sumBy (fun y -> square[x][y]))
          [ 0 .. m - 1 ]
          |> List.map (fun x ->
              [ 0 .. m - 1 ] |> List.sumBy (fun y -> square[y][x]))
          [ [ 0 .. m - 1 ] |> List.sumBy (fun x -> square[x][x]) ] ]
        |> List.concat
        |> List.pairwise
        |> List.forall (fun (x, y) -> x = y)

    if isMagic then
        printfn "Magic square of size %d" m
    else
        printfn "Not a magic square"
