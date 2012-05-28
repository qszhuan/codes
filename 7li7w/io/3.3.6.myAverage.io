List myAverage := method(
     self foreach(item, if(item type != "Number", Exception raise(item asString .. " is not number")))
     self sum / self size)

list(1,2,3) myAverage println
list(1,2,"3") myAverage println