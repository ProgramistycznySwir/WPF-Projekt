## Treść zadania:
Lista zadań do wykonania: powinna umożliwiać dodawanie zadań i odznaczanie ich wykonania. Zadania mogą należeń do różnych kategorii, mieć różny stopień pilności. Niektóre zadania mogą mieć określony termin wykonania (lub rozpoczęcia i zakończenia). Do zadań możemy dodawać "pod-zadania" (kroki).

## Funkcjonalności:
Aplikacja będzie składała się z jednego widoku.
W głównym widoku będzie możliwość tworzenia zadań. Zadania będą tworzone w formie kafelków, które można przesuwać pomiędzy trzema kolumnami: "Do zrobienia", "rozpoczęte" i "skończone". Kafelki będą zawierały pole z nazwą zadania, kolorową ramkę oznaczającą priorytet, tagi oznaczające kategorię, opcjonalne polce z zaznaczeniem daty rozpoczęcia i zakończenia oraz opcjonalną rozwijaną listę pod-zadań z checkboxami do zaznaczania ich wykonania.

## Opis GUI:
- Dodawanie zadań - button w widoku głównym otwierający pop-up z kreatorem kafelka
- Odznaczanie wykonania zadań - przesuwanie kafelka pomiędzy kolumnami
- Kategorie - tagi widoczne na kafelku z opcją usunięcia/dodania
- Stopień pilności - kolorowe ramki oznaczające poziom pilności
- Termin wykonania - jeśli przy kreacji kafelka zostaną podane daty, pojawią się na dole kafelka
- Pod-zadania (kroki) - rozwijana lista checkboxów z wypisanymi krokami 
- Edytowanie i usuwanie - przycisk "...", otwierające ponownie pop-up kreatora kafelka, w którym można edytować lub usuwać.

## Rozwiązania back-end'owe:
- Zadania będą miały strukturę drzewiastą.
    - Lista zadań to będzie task z tagiem "root" i Task.Parent_ID == null.
    - Zadania w liście będą miały jako rodzica zadanie z tagiem "root".
    - Pod-zadania będą miały jako rodzica inne zadanie.
- Postęp zadań będzie definiowany przez TagCategory o nazwie "Progress".





