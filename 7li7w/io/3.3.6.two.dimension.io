TwoDimension := Object clone

TwoDimension dim := method(
	     x := doMessage(call message argAt(0))
	     y := doMessage(call message argAt(1))
	     self this := List clone
	     for(i,1,y, this append(List clone setSize(x))))

ll := TwoDimension clone
ll dim(2,3) println


TwoDimension set := method(
	     x := doMessage(call message argAt(0))
	     y := doMessage(call message argAt(1))
	     self this atPut(y-1, x))

ll set(list(1,2,3), 2)

ll println


TwoDimension get := method(
	     x := doMessage(call message argAt(0))
	     y := doMessage(call message argAt(1))
	     self this at(y-1) at(x-1))

ll get(1,2) println
