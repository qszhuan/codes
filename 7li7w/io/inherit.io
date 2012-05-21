Vehicle := Object clone
Vehicle description := "Something to take you places"

Car := Vehicle clone
Car println
Car slotNames println 		#找不到description
Car description println 	#会把description消息转给原型Vehicle

Car description = "Car's description"	#只会改变Car的description槽
Car description println
Vehicle description println

ferrari := Car clone
ferrari slotNames println	#小写字母开头
ferrari type println 		#得到Car的type

ferrari clone println		#different with ferrari
ferrari println

