## List operations

toDos := list("find my car", "find continum Transfunctioner")
toDos size println

toDos append("Find a present")
toDos println

#calculations
list(1,2,3,4) average println
list(1,2,3,4) sum println
list(1,2,3,4) at(1) println
list(1,2,3,4) append(5) println
list(1,2,3,4,5) pop println
list(1,2,3,4) prepend(0) println

list() isEmpty println

## map
elvis := Map clone println
elvis atPut("home", "Graceland") 
elvis at("home") println
elvis atPut("style", "Rock and Roll")

elvis asObject println
elvis asList println
elvis keys println
Map slotNames println

