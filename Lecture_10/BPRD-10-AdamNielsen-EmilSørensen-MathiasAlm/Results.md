# 11.1
## i
> lenc [2; 5; 7] id;;
val it: int = 3

> lenc [2; 5; 7] (printf "The answer is ’% d’ \n");;
The answer is ’ 3’ 
val it: unit = ()

## ii
> lenc [2; 5; 7] (fun v -> 2*v);;
val it: int = 6

Instead of having the result 3 we multiply it by two: 3 * 2 = 6.

## iii
> leni [2; 5; 7] 0;;
val it: int = 3

The relationship between leni and lenc is that while leni iteratively increments an accumulator, lenc applies a function to the accumulated result, making the relationship: lenc xs cont is equivalent to cont (leni xs 0).

# 11.2
## i
> revc [2;5;7] id;;
val it: int list = [7; 5; 2]

## ii
> revc [2;5;7] (fun v -> v @ v);;
val it: int list = [7; 5; 2; 7; 5; 2]

The list is being duplicated.

## iii
> revi [2;5;7] [];;
val it: int list = [7; 5; 2]

The relationship is similar to the last exercise 11.1 iii: revc xs cont ≡ cont (revi xs [])
The CPS version applies the continuation to the result that the tail-recursive version computes.

# 11.4
> prodc_opt [2; 5; 7] id;;
val it: int = 70

> prodc_opt [2; 5; 7] (printf "The answer is ’% d’ \n");;

  prodc_opt [2; 5; 7] (printf "The answer is ’% d’ \n");;
  ----------------------------^^^^^^^^^^^^^^^^^^^^^^^^

stdin(4,29): error FS0001: Type mismatch. Expecting a
    'int -> int'    
but given a
    'int -> unit'    
The type 'int' does not match the type 'unit'

Since we are being told that CPS version of prod needs to take a function given an int returns an int, the prinf is not valid since it returns unit.

# 11.8
## i
let task1 = Every(Write(Prim("+", Prim("*", FromTo(1, 4), CstI 2), CstI 1)))

let task2 = Every(Write(Prim("+", Prim("*", FromTo(2, 4), CstI 10), FromTo(1, 2))))

> run task1;;
3 5 7 9 val it: value = Int 0

> run task2;;
21 22 31 32 41 42 val it: value = Int 0

## ii
let task3 = Write(Prim("<", CstI 50, Prim("*", FromTo(1, 100), CstI 7)))

> run task3;;
56 val it: value = Int 56
