# 6.1
## 1
7

## 2
7

## 3
We expected 7 and got 7.

## 4
We only give one paramater, so we get returned a function that can take one more parameter.

# 6.5
## 1
### 1
val it: string = "int"

### 2
It was unable to figure out a type due to circularity from g having g as its only parameter.

### 3
val it: string = "bool"

### 4
The if statement tries to return either an int or a bool, so it breaks.

### 5
val it: string = "bool"

## 2
### bool -> bool
inferType(fromString"
let f x = x = true in f end
");;

val it: string = "(bool -> bool)"

### int -> int
inferType(fromString"
let f x = x + 0 in f end
");;

val it: string = "(int -> int)"

### int -> int -> int
inferType(fromString"
let f x = let g y = x + y in g end in f end
");;

val it: string = "(int -> (int -> int))"

### 'a -> 'b -> 'a
inferType(fromString"
let f x = let g y = x in g end in f end
");;

val it: string = "('h -> ('g -> 'h))"

### 'a -> 'b -> 'b
inferType(fromString"
let f x = let g y = y in g end in f end
");;

val it: string = "('g -> ('h -> 'h))"

### ('a -> 'b) -> ('b -> 'c) -> ('a -> 'c)
ISH
inferType(fromString"
let f x = 
    let g y =
        let h z = z
        in f h
        end
    in f g
    end
in f end
");;

### 'a -> 'b
inferType(fromString"

");;

### 'a
inferType(fromString"

");;