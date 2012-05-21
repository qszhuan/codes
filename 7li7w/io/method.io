
method("It is a method" println) println 	#define a method

method type println							#method's type is Block

Car := Object clone
Car drive := method("Vroom" println)		#assign a method to a slot

Car drive 									#will call method when invoke the slot

ferrari := Car clone
ferrari drive

ferrari getSlot("drive") println			#get slot content
ferrari getSlot("type") println

ferrari proto println
bmw := Car clone
bmw proto println							#is same with ferrari's proto
ferrari println
bmw println									#is different with ferrari

Lobby println								#main namespace, contains all named object