#loop("endless loop" println)

i := 1
while(i <= 11, i println; i= i+1); "This one goes up to 11" println
for(i, 1,11, i println);"This one goes up to 11" println
for(i, 1,11, 2, i println); "This one goes up to 11" println	# set step， 
for(i, 1, 2, i println, "extra argument")  # the "i println" will be treat as step!

if(true, "It is true", "It is false") println
if(false) then("It is true") else("It is false") println
if(false) then("It is true." println) else("It is false." println)

OperatorTable println

OperatorTable addOperator("xor", 11)

true xor := method(bool, if(bool, false, true))
false xor := method(bool, if(bool, true, false))


true xor false println
(true xor true) println
(false xor true) println
(false xor false) println
