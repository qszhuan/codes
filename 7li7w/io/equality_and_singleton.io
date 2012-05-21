4 < 5 println
(true and false) println
(true and 0) println
true proto println

true clone					# is true, singleton

Highlander := Object clone
Highlander println
Highlander1 := Highlander clone 	
Highlander1 println	
Highlander2 := Highlander clone 	# is different with Highlander1
Highlander2 println	

Highlander clone := Highlander 		# rewrite define clone in Highlander

Highlander3 := Highlander clone		# is same with Highlander
Highlander3 println