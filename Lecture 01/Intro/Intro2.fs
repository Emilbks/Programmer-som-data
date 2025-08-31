(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)]

let emptyenv = [] (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x

let cvalue = lookup env "c"


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr

let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

let eMax = Prim("max", CstI 5, CstI 7)

let eMin = Prim("min", Prim ("-", CstI 8, CstI 3), CstI 7)

let eEqTrue = Prim("==", Prim ("+", CstI 6, CstI 4), Prim ("*", CstI 2, CstI 5))

let eEqFalse = Prim("==", Prim ("-", CstI 6, CstI 4), Prim ("*", CstI 2, CstI 5))

let eIf = If (Var "a", CstI 11, CstI 22)


(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x 
    | Prim (ope, e1, e2) ->
        let i1 = eval e1 env
        let i2 = eval e2 env
        match ope with
        | "+" -> i1 + i2
        | "-" -> i1 - i2
        | "*" -> i1 * i2
        | "max" -> max i1 i2
        | "min" -> min i1 i2
        | "==" -> if i1 = i2 then 1 else 0
        | _ -> failwith "unknown primitive"
    | If (e1, e2, e3) ->
        if eval e1 env <> 0 then eval e2 env else eval e3 env


let e1v  = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [("a", 314)]
let e3v  = eval e3 env
let eMaxv = eval eMax env
let eMinv = eval eMin env
let eEqTruev = eval eEqTrue env
let eEqFalsev = eval eEqFalse env
let eIf11 = eval eIf env
let eIf22 = eval eIf [("a", 0)]

// Exerice 1.2.1
type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Sub of aexpr * aexpr
  | Mul of aexpr * aexpr

(*
Exercise 1.2.2

v - (w + z) = Sub (Var "v", Add (Var "w", Var "z"))

2 * (v - (w + z) = Mul (CstI 2, Sub (Var "v", Add (Var "w", Var "z")))

x + y + z + v = Add (Var "x", Add (Var "y", Add (Var "z", Var "v")))

*)

// Exercise 1.2.3
let rec fmt (a: aexpr) : string =
    match a with
    | CstI i -> $"{i}"
    | Var v -> $"{v}"
    | Add (e1, e2) -> $"({fmt e1} + {fmt e2})"
    | Sub (e1, e2) -> $"({fmt e1} - {fmt e2})"
    | Mul (e1, e2) -> $"({fmt e1} * {fmt e2})"

// Exercise 1.2.4
let simplify (a: aexpr) : aexpr =
    match a with
    | Add (CstI 0, e) -> e
    | Add (e, CstI 0) -> e
    | Sub (e, CstI 0) -> e
    | Mul (CstI 1, e) -> e
    | Mul (e, CstI 1) -> e
    | Mul (e, CstI 0) -> CstI 0
    | Mul (CstI 0, e) -> CstI 0
    | Sub (e1, e2) when e1 = e2 -> CstI 0
    | _ -> a

// Exercise 1.2.5
let rec diff (a: aexpr) (var: string) : aexpr =
    match a with
    | CstI _ -> CstI 0
    | Var x -> if x = var then CstI 1 else CstI 0
    | Add (e1, e2) -> Add (diff e1 var, diff e2 var)
    | Sub (e1, e2) -> Sub (diff e1 var, diff e2 var)
    | Mul (e1, e2) -> Add(Mul(diff e1 var, e2), Mul(e1, diff e2 var))