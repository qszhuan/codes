#sum up 2 dimension array
List sum2 := method(
     result := List clone
     self foreach(item, result append(item sum))
     result sum
)

list(list(1,2), list(3,4,5)) sum2 println