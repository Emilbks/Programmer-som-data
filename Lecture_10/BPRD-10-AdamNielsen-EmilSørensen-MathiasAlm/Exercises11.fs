module Exercises11

// 11.1
let rec lenc (lst: 'a list) (cont: int -> 'b) : 'b =
    match lst with
    | [] -> cont 0
    | x::xs -> lenc xs (fun v -> cont (v + 1))
// 11.1
let rec leni (lst: int list) (acc: int) : int =
    match lst with
    | [] -> acc
    | x::xs -> leni xs (1 + acc)

// 11.2
let rec revc (lst: 'a list) (cont: 'a list -> 'a list) : 'a list =
    match lst with
    | [] -> cont []
    | x::xs -> revc xs (fun v -> cont (v @ [x]))
// 11.2
let rec revi (lst: 'a list) (acc: 'a list) : 'a list =
    match lst with
    | [] -> acc
    | x::xs -> revi xs (x :: acc)

// 11.3
let rec prodc (lst: int list) (cont: int -> int) : int =
    match lst with
    | [] -> cont 1
    | x::xs -> prodc xs (fun v -> cont (x * v))

// 11.4
let rec prodc_opt (lst: int list) (cont: int -> int) : int =
    match lst with
    | [] -> cont 1
    | 0::_ -> 0
    | x::xs -> prodc xs (fun v -> cont (x * v))
// 11.4
let rec prodi (lst: int list) (acc: int) : int =
    match lst with
    | [] -> acc
    | 0::_ -> 0
    | x::xs -> prodi xs (x * acc)