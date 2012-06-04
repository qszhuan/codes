min(X, Y, X) :- \+(X>Y).
min(X, Y, Y) :- X > Y.

small([], nil).
small([X], X).
small([Head|Tail], Min) :- small(Tail, Tmp), min(Head, Tmp, Min).