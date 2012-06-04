fib(1, 1).
fib(2, 1).

fib(N, F) :- N > 2, A is N-1, B is N-2, fib(A, X), fib(B, Y), F is X + Y.

fibs(1,[1]).
fibs(N, [Head|Tail]) :- fib(N, Head), A is N-1, fibs(A, Tail).

fibs2(1,[1]).
fibs2(N, List) :- fib(N, NR), A is N-1, fibs2(A, Tail), append(Tail, [NR], List).