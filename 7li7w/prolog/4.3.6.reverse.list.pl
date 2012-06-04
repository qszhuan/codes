reverse2([], []).
%-- reverse2([X], [X]).

reverse2([Head|Tail], RList) :- reverse2(Tail, RTail), append(RTail, [Head], RList).

%-- tail recursion optimization
reverse3([], RList, RList).
reverse3([Head|Tail], F, RList) :- reverse3(Tail, [Head|F], RList).