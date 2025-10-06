// 6.1
let merge (xs : int list, ys : int list) : int list =
    let rec loop (xs : int list) (ys : int list) (output : int list) : int list =
        match xs, ys with
        | x::xs', y::_ when x <= y -> loop xs' ys (x::output)
        | x::_, y::ys' when x > y -> loop xs ys' (y::output)
        | x::xs', [] -> loop xs' ys (x::output)
        | [], y::ys' -> loop xs ys' (y::output)
        | [], [] -> output |> List.rev
    loop xs ys []