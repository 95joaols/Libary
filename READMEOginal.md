# Inlämningsuppgift - Biblioteket
## Läs igen hela denna uppdragsbeskrivning noggrant.

Deadline för inlämning: Måndag den 26:e Oktober kl 23:59
Inlämning sker via GitHub Classroom.

### För G krävs följande i inlämningen:

1. Du har planerat din lösning på ett lämpligt sätt. Bifoga exempelvis pseudokod/klassdiagram.
2. Du har skapat en körbar konsolapplikation i C# ( lösningen kommer att testas i Visual Studio Code. )
3. Du har enskilt planerat och skapat en enkel men välstrukturerad applikation med hjälp av språket C#.
4. Du har skrivit en rapport för uppgiften som sammanfattar din lösning och tillvägagångssätt samt värderar hur bra du själv tycker att du lyckats med uppgiften. Rapporten skall vara skriven i denna Readme.md-fil (All denna text är ok att ta bort). _Ha med en lista på vilka funktionskrav du anser att ditt program uppfyller!_
5. Minst 9 av 13 funktionskrav måste vara uppfyllda.

---
### För VG krävs också följande i inlämningen:

6. 12 av 13 funktionskrav måste vara uppfyllda.
7. Din struktur skapar förutsättningar för effektivt underhåll och möjlighet till vidareutveckling. Detta innefattar prydlig och konsekvent kod.
8. Analysera och reflektera kring hur du uppfyllt kraven i uppgiften. Reflektera över din applikations funktion och kodstruktur - samt motivera dina ställningstaganden.

## Uppgiftsbeskrivning:

Som programmerare har du blivit kontaktad av ett bibliotek som vill att du gör ett ideellt arbete åt dem. Självklart tackar du ja!

Biblioteket skall starta ett pilotprojekt och införa digital hantering av deras böcker! Som första steg skall du ska skapa ett grundläggande konsolprogram som innehåller funktioner för att registrera nya böcker samt söka i biblioteket bland dessa böcker.

## Funktionskrav

* Lösningen ska innehålla klassen _Book_ med minst tre egenskaper: titel, skribent och utgivningsår. 
* _Book-klassen_ ska ärvas av minst tre underklasser av böcker. Förslagsvis _Roman_, _Tidskrift_ och _Novellsamling_. 
* Lösningen ska innehålla en klass kallad Library (bibliotek), som ska innehålla en lista med böcker. Listan måste vara private och andra klasser kan bara integrera med listan med hjälp av metoder. 
* Bibliotek-klassen ska ha minst fyra publika metoder:
  * En för att lägga till en bok i listan 
  * En för att lägga till flera böcker samtidigt (en lista med böcker) 
  * En för av skriva ut alla böcker i biblioteket. 
  * En för att söka bland böckerna i bokhyllan med en given sträng (indata) 
* Varje underklass till Book: tidskrift, roman, novellsamling; ska ha en egen override av ToString metod som ska användas när alla böcker i biblioteket listas. Den metoden ska ge tillbaka olika strängar beroende på vilken klass det är. 
* Användaren ska genom en konsolmeny kunna:
  * Lägga till nya böcker i biblioteket
  * Lista alla böcker i biblioteket 
  * Söka efter en bok med ett givet namn. Boken ska matcha om det man söker efter finns någonstans i bokens titel, författarens namn eller i utgivningsåret och ska inte vara känsligt för stora eller små bokstäver.
* Varje bok som användaren sparar i Biblioteket ska vara ett eget objekt av typen Book.
* När programmet startar ska en färdigkonfiguerad lista av minst 5 böcker av olika typer från början finnas i biblioteket.

---

### Tips och riktlinjer:

* Inlämning av uppgiften sker via GitHub Classroom. Har du problem med att få det att fungera, se till att få hjälp med det i god tid! 
* Ni ska dokumentera er lösning (mål 4) i denna Readme.md fil som finns i repot. Ta gärna bort alla denna text och ersätt med din rapport.
* När ni skriver er rapport (mål 4), beskriv vad fördelarna är med er struktur. Vad är den ev. problematiken om programmet skulle växa och utökas.
* Mål 1 kommer bedömas utifrån er rapport jämte ert kodresultat. Dokumentera med fördel med hjälp av ev. flöde- & klassdiagram eller hur ni från er synvinkel förstått uppgiften.
* All form av koddelning är otillåten och innebär automatiskt U i betyg. Använder ni en färdig lösning från exempelvis Stack Overflow måste ni dokumentera- samt motivera detta i kodkommmentarer.
* Se till att ditt program kan hantera felaktig inmatning och inte kraschar.
* För en bra struktur, tänk på att separera "inmatningen av information" från "bibliotek- och bok-klasserna". Dom ska alltså inte använda sig av Console någonstans.
* För att veta hur sökning går till behöver ni ev. slå upp och hitta information på nätet. Om ni inte klarar av detta steg så är det viktigaste att ni dokumenterar och reflekterar kring detta i er rapport.
* Deadline kollas mot det senaste comitten, så se till att pusha ditt lokala repository innan ** Måndag den 26:e Oktober kl 23:59 **
* **Kom ihåg, mer kod betyder inte bättre kod! Hellre eleganta lösningar än mycket extra funktionalitet utöver kravspecen!**

Lycka till!
