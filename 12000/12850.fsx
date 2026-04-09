let matrix =
    [| [| 0L; 1L; 1L; 0L; 0L; 0L; 0L; 0L |]
       [| 1L; 0L; 1L; 1L; 0L; 0L; 0L; 0L |]
       [| 1L; 1L; 0L; 1L; 1L; 0L; 0L; 0L |]
       [| 0L; 1L; 1L; 0L; 1L; 1L; 0L; 0L |]
       [| 0L; 0L; 1L; 1L; 0L; 1L; 1L; 0L |]
       [| 0L; 0L; 0L; 1L; 1L; 0L; 0L; 1L |]
       [| 0L; 0L; 0L; 0L; 1L; 0L; 0L; 1L |]
       [| 0L; 0L; 0L; 0L; 0L; 1L; 1L; 0L |] |]

let (*) (a: int64[][]) (b: int64[][]) =
    Array.init 8 (fun i ->
        Array.init 8 (fun j ->
            seq [ 0..7 ]
            |> Seq.map (fun k -> a[i][k] * b[k][j])
            |> Seq.reduce (fun x y -> (x + y) % 1000000007L)))

let rec pow a n =
    if n = 1 then
        a
    else
        let mid = pow a (n / 2)
        let a' = mid * mid

        if n % 2 = 0 then a' else a' * a

let matrix' = stdin.ReadLine() |> int |> pow matrix
printfn "%d" (matrix'[0][0])
