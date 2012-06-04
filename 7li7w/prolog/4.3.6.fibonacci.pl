fib(1, 1).
fib(2, 1).

fib(N, F) :- N > 2, A is N-1, B is N-2, fib(A, X), fib(B, Y), F is X + Y.
