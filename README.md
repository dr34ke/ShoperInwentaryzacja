# ShoperInwentaryzacja
To prosta darmowa aplikacja, wspomagajaca działanie sklepu na platformie [Shoper.pl](http://shoper.pl). Jej głównym i w zasadzie jedynym zadaniem jest przeprowadzanie inwentaryzacji magazynów Aplikacji sklepu internetowego i zmiana stanow magazynowych na te odzwierciedlajace rzeczywiste ilości posiadanych produktów. Do poprawnego działania wymagany jest Sql server.

## Strona główna
Na stronie głównej zalogowany użytkownik ma podgląd swoich dodanych sklepów, oraz datę wygaśnięcia tokenu aplikacji.

![scr1](https://github.com/dr34ke/ShoperInwentaryzacja/blob/master/scr1.png)

## Widok listy przeprowadzonych inwentaryzacji
W tym widoku użytkownik ma dostep do przeprowadzonych już wcześniej inwentaryzacji, może dodać kolejną, lub w zależności od statusu juz przeprowadzonej inwentaryzcji może podejrzeć raport lub dokoćzyć inwentaryzację.
Inwentaryzację można przeprowadzić w 3 trybach:
1. Wrostek Sku- Pobierane są wszystkie przedmioty ze sklepu posiadające w swoim sku składową wpisaną do bazy (np. cpu% wyszukuje wszystkie przedmioty któreych sku zaczyna się od cpu).
2. Kategoria- Pobierane są wszystkie przedmioty ze sklepu z uwzględnieniem kategorii. 
3. Kategoria + wrostek SKU - Pobierane są wszystkie przedmioty ze sklepu z uwzględnieniem kategorii, a następnie filtrowane przez wroostek sku.

![scr2](https://github.com/dr34ke/ShoperInwentaryzacja/blob/master/scr2.png)

## Widok inwentaryzacji
W tym widoku użytkownik dostaje narzędzie do sprawdzania stanów magazynowych, za pomocą czytnika kodów kreskowych lub wpisywania ręcznie wartości, ilości dodawane można korygować ręcznie dla każdego produktu z osobna.
 
 ![scr3](https://github.com/dr34ke/ShoperInwentaryzacja/blob/master/scr3.png)
 
 ## Widok porównania stanów
 W tym widoku użytkownik dostaje zestawienie wyników przeprowadzonej kotroli stanów magazynowych, może wybrać z listy elementy których ilości chce zmienić. Domyślnie zaznaczone są elementy których stan magazynowy różni się od stanu rzeczywistego.
 Po dokonaniu tej czynności użytkownik powinien wygenerować raport w którego skład wejdzie zestawienie przedmiotów do których edycji przystapi aplikacja.
 
 ![scr4](https://github.com/dr34ke/ShoperInwentaryzacja/blob/master/scr4.png)
  
  ## Podgląd zmian
  W tym widoku użytkownik dostaje widok wszystkich elementów ktorych stan magazynowy ulegnie zmianie, oraz narzędzie przeprowadzające cały proces. Po ukończeniu procesu generowany jest raport przeprowadzanych prac oraz zmieniany jest status inwentaryzacji na "Zakończona".
  
  ![scr5](https://github.com/dr34ke/ShoperInwentaryzacja/blob/master/scr5.png)
  
  ## Raport przeprowadzonych zmian
  
  Ostatnim z widoków jest raport zawierający id produktu, ustanowiony stan magazynowy oraz status informujący o sukcesie zmian.
  ![scr6](https://github.com/dr34ke/ShoperInwentaryzacja/blob/master/scr6.png)
