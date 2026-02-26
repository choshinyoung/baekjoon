let input () =
    stdin.ReadLine().Split() |> Array.map int

let [| _; m; _ |] = input ()
let blocks = input ()

let spaces =
    [| 0; yield! input (); m + 1 |]
    |> Array.pairwise
    |> Array.choose (fun (a, b) ->
        if b - a > 1 then Some(a + 1, b - 1) else None)

let left =
    Array.mapFold
        (fun (s, last) block ->
            let rec find i =
                let s, e = spaces[i]
                let s' = max s (last + 1)

                if e - s' + 1 >= block then
                    let e' = s' + block - 1
                    (s', e'), (i, e')
                else
                    find (i + 1)

            find s)
        (0, 0)
        blocks
    |> fst

let right =
    Array.mapFoldBack
        (fun block (s, last) ->
            let rec find i =
                let s, e = spaces[i]
                let e' = min e (last - 1)

                if e' - s + 1 >= block then
                    let s' = e' - block + 1
                    (s', e'), (i, s')
                else
                    find (i - 1)

            find s)
        blocks
        (spaces.Length - 1, m + 1)
    |> fst

let result =
    (left, right)
    ||> Array.map2 (fun (_, el) (sr, _) -> max 0 (el - sr + 1))
    |> Array.sum

printfn "%A" result
