type Shark = { speed: int; dir: int; size: int }

let [| r; c; m |] = stdin.ReadLine().Split() |> Array.map int

let map = Array2D.create r c -1

let sharks =
    Array.init m (fun i ->
        let input = stdin.ReadLine().Split() |> Array.map int
        map[input[0] - 1, input[1] - 1] <- i

        { speed = input[2]
          dir = input[3]
          size = input[4] })

let rec simulate (map: int[,]) position =
    if position >= c then
        0
    else
        let catch =
            [ 0 .. r - 1 ]
            |> List.tryFindIndex (fun y -> map[y, position] <> -1)

        let score =
            match catch with
            | Some y -> sharks[map[y, position]].size
            | _ -> 0

        if catch.IsSome then
            map[catch.Value, position] <- -1

        let map' = Array2D.create r c -1

        for y in 0 .. r - 1 do
            for x in 0 .. c - 1 do
                if map[y, x] <> -1 then
                    let idx = map[y, x]
                    let shark = sharks[idx]

                    let cycle =
                        if shark.dir < 3 then (r - 1) * 2 else (c - 1) * 2

                    let speed =
                        if cycle > 0 then shark.speed % cycle else 0

                    let rec move y' x' dir' s =
                        if s = 0 then
                            y', x', dir'
                        else
                            match dir' with
                            | 1 ->
                                if y' = 0 then
                                    move 1 x' 2 (s - 1)
                                else
                                    move (y' - 1) x' 1 (s - 1)
                            | 2 ->
                                if y' = r - 1 then
                                    move (r - 2) x' 1 (s - 1)
                                else
                                    move (y' + 1) x' 2 (s - 1)
                            | 3 ->
                                if x' = c - 1 then
                                    move y' (c - 2) 4 (s - 1)
                                else
                                    move y' (x' + 1) 3 (s - 1)
                            | 4 ->
                                if x' = 0 then
                                    move y' 1 3 (s - 1)
                                else
                                    move y' (x' - 1) 4 (s - 1)

                    let y', x', dir' = move y x shark.dir speed
                    sharks[idx] <- { shark with dir = dir' }

                    if
                        map'[y', x'] = -1
                        || shark.size > sharks[map'[y', x']].size
                    then
                        map'[y', x'] <- idx

        score + simulate map' (position + 1)

simulate map 0 |> printfn "%d"
