different(red, green).
different(red, blue).
different(green, red).
different(green, blue).
different(blue, green).
different(blue, red).

coloring(Albama, Mississippi, Georgia, Tennessee, Florida) :-
different(Mississippi, Tennessee),
different(Mississippi, Albama),
different(Albama, Tennessee),
different(Albama, Mississippi),
different(Albama, Georgia),
different(Albama, Florida),
different(Georgia, Florida),
different(Georgia, Tennessee).


colormap(Albama, Mississippi, Georgia, Tennessee, Florida) :-
Range = [red, blue, green],
member(Albama, Range),
member(Mississippi, Range),
member(Georgia, Range),
member(Tennessee, Range),
member(Florida, Range),
\+(Mississippi = Tennessee),
\+(Mississippi = Albama),
\+(Albama = Tennessee),
\+(Albama = Mississippi),
\+(Albama = Georgia),
\+(Albama = Florida),
\+(Georgia = Florida),
\+(Georgia = Tennessee).