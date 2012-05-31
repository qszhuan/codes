instrument(langlang, piano).
instrument(jaychou, piano).
instrument(beethoven, piano).
instrument(douwei, flute).
instrument(douwei, erheen).

flavor(langlang, classic).
flavor(beethoven, classic).
flavor(jaychou, popmusic).
flavor(douwei, rock).
flavor(douwei, light_music).

ins_flavor(Instrument, Flavor) :-
instrument(Musician, Instrument),
flavor(Musician, Flavor).