let n = stdin.ReadLine() |> int

let tiles =
    Array.init n (fun _ -> stdin.ReadLine().Split() |> Array.map int)

let left tiles =
    let tiles' = tiles |> Array.map Array.copy
    let index = Array.create n -1
    let updated = Array.zeroCreate n

    for x in 0 .. n - 1 do
        for y in 0 .. n - 1 do
            let tile = tiles[y][x]
            tiles'[y][x] <- 0

            if tile <> 0 then
                if
                    index[y] <> -1
                    && tiles'[y][index[y]] = tile
                    && not (updated[y])
                then
                    tiles'[y][index[y]] <- tile * 2
                    updated[y] <- true
                else
                    index[y] <- index[y] + 1
                    tiles'[y][index[y]] <- tile
                    updated[y] <- false

    tiles'

let right tiles =
    let tiles' = tiles |> Array.map Array.copy
    let index = Array.create n n
    let updated = Array.zeroCreate n

    for x in n - 1 .. -1 .. 0 do
        for y in 0 .. n - 1 do
            let tile = tiles[y][x]
            tiles'[y][x] <- 0

            if tile <> 0 then
                if
                    index[y] <> n
                    && tiles'[y][index[y]] = tile
                    && not (updated[y])
                then
                    tiles'[y][index[y]] <- tile * 2
                    updated[y] <- true
                else
                    index[y] <- index[y] - 1
                    tiles'[y][index[y]] <- tile
                    updated[y] <- false

    tiles'

let up tiles =
    let tiles' = tiles |> Array.map Array.copy
    let index = Array.create n -1
    let updated = Array.zeroCreate n

    for y in 0 .. n - 1 do
        for x in 0 .. n - 1 do
            let tile = tiles[y][x]
            tiles'[y][x] <- 0

            if tile <> 0 then
                if
                    index[x] <> -1
                    && tiles'[index[x]][x] = tile
                    && not (updated[x])
                then
                    tiles'[index[x]][x] <- tile * 2
                    updated[x] <- true
                else
                    index[x] <- index[x] + 1
                    tiles'[index[x]][x] <- tile
                    updated[x] <- false

    tiles'

let down tiles =
    let tiles' = tiles |> Array.map Array.copy
    let index = Array.create n n
    let updated = Array.zeroCreate n

    for y in n - 1 .. -1 .. 0 do
        for x in 0 .. n - 1 do
            let tile = tiles[y][x]
            tiles'[y][x] <- 0

            if tile <> 0 then
                if
                    index[x] <> n
                    && tiles'[index[x]][x] = tile
                    && not (updated[x])
                then
                    tiles'[index[x]][x] <- tile * 2
                    updated[x] <- true
                else
                    index[x] <- index[x] - 1
                    tiles'[index[x]][x] <- tile
                    updated[x] <- false

    tiles'

let rec simulate depth tiles =
    if depth = 5 then
        tiles |> Array.concat |> Array.max
    else
        [ left tiles; right tiles; up tiles; down tiles ]
        |> List.map (simulate (depth + 1))
        |> List.max

simulate 0 tiles |> printfn "%d"
