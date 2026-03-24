let rec solve c =
    match stdin.ReadLine() with
    | null -> ()
    | x ->
        let [| n; t |] = x.Split()

        let n' =
            match n with
            | "A#" -> "Bb"
            | "C#" -> "Db"
            | "D#" -> "Eb"
            | "F#" -> "Gb"
            | "G#" -> "Ab"
            | "Ab" -> "G#"
            | "Gb" -> "F#"
            | "Eb" -> "D#"
            | "Db" -> "C#"
            | "Bb" -> "A#"
            | _ -> ""

        printf "Case %d: " c

        if n' <> "" then printfn "%s %s" n' t else printfn "UNIQUE"
        solve (c + 1)

solve 1
