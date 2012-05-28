#if divide zero, return 0
OperatorTable slotNames println

origDiv := Number getSlot("/")
Number / := method(i,
       if(i == 0, 0, origDiv(i)))

2/3 println
3/1 println
3/0 println