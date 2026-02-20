open System
open System.Text

let N = Console.ReadLine() |> int
let A = Console.ReadLine().Split() |> Array.map int

let dp = Array.init N (fun _ -> Array.create N false)
let visited = Array.init N (fun _ -> Array.create N false)

for i in 0 .. (N - 1) do
    dp[i][i] <- true
    visited[i][i] <- true

let rec calc S E =
    if not (visited[S][E]) then
        dp[S][E] <- S > E || A[S] = A[E] && calc (S + 1) (E - 1)
        visited[S][E] <- true

    dp[S][E]

let M = Console.ReadLine() |> int
let sb = StringBuilder()

for _ in 1..M do
    let [| S; E |] = Console.ReadLine().Split() |> Array.map int
    (if calc (S - 1) (E - 1) then "1" else "0") |> sb.AppendLine |> ignore

sb.ToString() |> printfn "%s"
