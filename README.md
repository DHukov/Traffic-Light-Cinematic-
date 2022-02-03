# Trafic_Light_TestTask
This projekt is Test Task for one of IT team from Łódź



 ZADANIA TESTOWE


Zadanie 1. 

Zadanie 1 znajduje się w obiekcie "For" na scenie "SampleScene". Na tym obiekcie będzie skrypt z kodem(Lub ścieżka w projekcie do kodu: „Trafic_Light_TestTask\Assets\_Scripts\For”)
 
Kompilacja się zacznie po uruchomieniu sceny i wyniki będą widoczne  w Window - Panels - Console (Debug.Log).    

Pod sam koniec jednak straciłem pewność co do prawidłowości wykonania zadania, moim zdaniem brakowało przykładowych wyników prawidłowo wykonanego zadania. Wątpliwości dotyczące tego, czy mogą liczby podzielne przez 3, 5, 15 być powtarzane, na przykład 30 / 3 = Ba(10), 30 / 5 = za(6), 30 / 15 = Baza(2). 

Czy miało być tak, że ciąg liczb nie jest powtarzany, i wyglądać następująco:
25 "za"
26 
27 "Ba"
28 
29
30 "Ba" "za" "baza"   (lub sam napis "Baza"). 

Zadanie 2. 


a)	Zrealizowałem to zadanie za pomocą State Machine w Unity. Włączając i wyłączając potrzebne mi(cyklu świateł) materiały oraz światła. 

Przełączenie się odbywa dla każdego rodzaju światła osobno. Zielone, żółte, czerwone i dla każdego elementu osobno. Światła drogowe dla samochodów osobnym elementem od świateł dla pieszych. Nie chodzi tutaj o logikę przełączania z zielonego na czerwone, tylko bardziej o "zasilanie". (Jak na screenshocie)


Można sobie samemu ustawić czas całego cyklu:
Czerwone – Żółte – Zielone – Żólte
Zmienna – „TimeCycleOfTraffic”


Światła zielone trwa tak samo jak światła czerwone i na odwrót- czerwone jak zielone.
Wzór na to:

 greenCycleTime = (timeCycleOfTraffic - yellowTime * 2) / 2;

Światła żółte trwają zawsze 3 sekundy
Więc zmieniając czas całego cyklu program automatycznie dopasuje zmienne czerwonego oraz zielonego.


b)	Strzałka warunkowa włączy się na czerwonym świetle po 1 sekundzie od czerwonego


c)	Logika przełączeń świateł za pomocą przycisku jest zrealizowana następująco:
Jeśli po naszej stronie, gdzie "chcemy przejść" dla samochodów jest zielone, stąd wynika, że dla nas też powinno być zielone, ale po ile światła dla pieszych zawsze są "czerwone" możemy je przyłączyć i w takim przypadku światła koloru zielonego się zapalą w tym samym kierunku jak "samochody" mają zielone. 

Zrobiłem tak, że po dwóch sekundach od naciśnięcia przycisku się zapalają. Dla tego, żeby nie wyglądało to zbyt nagle. 
Tuż inna ścieżka, jeśli chcemy iść w kierunku poprzecznym do ruchu samochodów (Na przykład zielone dla osi Z), a my chcemy iść w kierunku osi X, i naciśniemy przycisk, to jednak i tak musimy poczekać na zmianę cyklu, i dopiero wtedy(czas oczekiwania na zmianę +_po dwóch sekundach) się wyłącza dla nas zielone światła.


Położenie świateł w taki sposób jest celowe, ponieważ ułatwia to testowanie cyklów.



Przycisk po lewej stronie Odpowiada za włączanie zielonego na osi Z dla gracza (na przejściu dla pieszych), po prawej – odwrotnie. 

Pzyciski mają błokade na późne wciśnięcie jego. To znaczy jeśli do zmiany świateł na czerwone zostaje się mniej niż „7” sekund, to przycisk nie zadziała. Zrobione to dla tego, żeby nie doprowadzić do sytuacji że pieszy naciśnie przycisk, wlączy się zielone i natychmiast światła się zmieniją na czerwone, bo już „podchodził” czas. 


https://www.linkedin.com/in/danylo-hukov-/





Zadania wykonywał Danylo Hukov

