author(martin).
author(james).

book(martin, refactoring).
book(martin, dsl).
book(james, donotknow).

list_book(Author, Book) :- author(Author), book(Author, Book).