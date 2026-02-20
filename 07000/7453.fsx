let n = stdin.ReadLine() |> int

let a = Array.init 4 (fun _ -> Array.zeroCreate n)

for i in 0 .. n - 1 do
    stdin.ReadLine().Split()
    |> Array.map int
    |> Array.iteri (fun j x -> a[j][i] <- x)

let sum a b =
    Array.allPairs a b |> Array.map (fun (x, y) -> x + y)

let sumAB = sum a[0] a[1] |> Array.sort
let sumCD = sum a[2] a[3] |> Array.sort

let rec search x y acc =
    if x >= n * n || y < 0 then
        acc
    else
        match sumAB[x] + sumCD[y] with
        | a when a < 0 -> search (x + 1) y acc
        | a when a > 0 -> search x (y - 1) acc
        | _ ->
            let count (a: int array) start step =
                let rec getNext i acc =
                    if i >= 0 && i < n * n && a[i] = a[start] then
                        getNext (i + step) (acc + 1L)
                    else
                        acc, i

                getNext start 0

            let countAB, x' = count sumAB x 1
            let countCD, y' = count sumCD y -1

            search x' y' (acc + countAB * countCD)

search 0 (n * n - 1) 0 |> printfn "%d"
