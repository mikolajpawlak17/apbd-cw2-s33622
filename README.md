1. W projekcie użyłem dwóch klas abstarkcyjnych(User, Equipment), aby osiągnąć w systemie opcję, że
nie ma po prostu użytkownika, tylko jest student albo pracownik. Dzięki temu już w konstruktorze
przypisuję im odpowiednie limity. Podobnie ze sprzętem(laptopy, kamery oraz projektory) mają swoje 
unikalne cechy, ale dzięki wspólnej klasie bazowej mogę nimi zarządzać w jednej liście.
2. Rozdzieliłem klasy przechowujące modele od głównej logiki. Wszystkie obliczenia odnośnie wypożyczeń,
zwrotów oraz sprawdzania dostępności sprzętu i limitów umieścilem w klasie Service. 
3. Używałem również gałęzi, aby rozdzielić różne etapy pracy, na osobnych gałęziach tworzyłem logikę odnośnie
sprzętów, wypożyczeń, użytkowników. Po każdej skończonej pracy łączylem daną gałąź z master.