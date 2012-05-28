## loop implement
fibonacci := method(
	  loops := call sender doMessage(call message argAt(0))
	  i := 1
	  j := 0
	  while(loops > 1, k := i; i = i+j; j = k; loops = loops - 1)
	  i println)


fibonacci(1)
fibonacci(2)
fibonacci(3)
fibonacci(4)

##recursive implement

fib := method(
    index := call sender doMessage(call message argAt(0))
    if(index == 1 or index == 2, 1, fib(index-1) + fib(index-2)))
fib(1) println
fib(2) println
fib(3) println
fib(4) println