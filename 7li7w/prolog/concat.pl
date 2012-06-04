concatenate([], List, List).
concatenate([Head|Tail], List, [Head|Tail2]) :- concatenate(Tail, List, Tail2).

