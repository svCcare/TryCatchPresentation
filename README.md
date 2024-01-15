Czym jest Error 
Definicja
Wygląd na produkcji
Podstawy obsługi wyjątków oraz słowa kluczowe
Try, Catch, Throw, Finally
Zagnieżdżenie bloku Try Catch
Throw vs Throw ex (never Throw Up)
Wyłapywanie konkretnych wyjątków (rzucony ArgumentException przechwytujemy Exception i vice versa)
Dobre praktyki level 1
Unikanie ifologi (why?)
Nie pozostawienie pustego catcha
TrySomething pattern
Od szczegółu do ogółu (Exception at the bottom)
Dokumentacje!
Wbudowane Exceptiony
Intellisense + tworzenie własnej dokumentacji
Dobre praktyki level 2
Stworzenie własnych Exception’ów
Benefity takiego podejścia (Use custom exception classes to provide more context about the error and make it easier to diagnose and fix issues in your application.)
Związek z DDD
Odnośnie ApplicationException
At least three common constructors
Podejście z ErrorHandler (Implement a centralized exception handling mechanism to handle exceptions consistently across your application.)
Exception Filters (kiedy ten sam error chcemy obsłużyć na różne sposoby) https://thomaslevesque.com/2015/06/21/exception-filters-in-c-6/
Złe praktyki level over 9000
Something went wrong - Zbyt generalne rzucanie wyjątków
Zwracanie wartości (np. -1) celem uniknięcia Throw (this might lead to exceptions not being noticed)

 



