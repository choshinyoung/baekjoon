let a=stdin.ReadLine
[for _ in 1..int(a())->a()]|>set|>Seq.sortBy String.length|>Seq.iter(printfn"%s")
