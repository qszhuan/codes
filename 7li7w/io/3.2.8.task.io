##1
a := 1+1
a println

#b := 1 + "one"		#will get an Error
#b println

##2
0 println
(0 == true) println	
(0 == false) println
("" == true) println
("" == false) println
(nil == true) println
(nil == false) println

0 type println
Number slotNames println

##3 #use slotNames slot

C := Object clone
C flag ::= 1
C println				#have a setFlag method
C setFlag(4)
C flag println

C state := 3			#there is no setter for state
C println
