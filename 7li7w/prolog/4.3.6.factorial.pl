factorial(0, 1).
factorial(N, R) :- N > 0, N1 is N -1, factorial(N1, T), R is N * T.


fact(1, F, F).
fact(N, T, F) :- N>1, T1 is N*T, N1 is N-1, fact(N1, T1, F).