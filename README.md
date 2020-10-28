# Biblioteket

## innehållsförteckning
1. Tack Ord
2. Rapport
3. Planerande
4. Genomförande

## Tack Ord
Tack för att Jag Har Fått Uppdraget.
Jag kommer att göra mitt bästa för att ni ska blir så nöjda som mögligt

# Rapport

Jag uppskatta att jag har klarat alla punkter genom:
1. Lösningen ska innehålla klassen _Book_ med minst tre egenskaper: titel, skribent och utgivningsår. 

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Book.cs#L1-L73

Jag har skapat en abstract klass med Property Title,Writer och Publikation.
Jag sätter den till abstract för att hindra att man ska kunna skapa den för sig skälv och för att lättare göra tostring() Annas måste jag kolla vilken typ och skicka vidare till sub klassen.
Propertya är satta till "protected set" för att bara denna och sub klasser ska kunna ändra värdena.
Jag kunde ha allt public men jag vill har mer kontroll.
BookTemle är för att resultatet av "protected set" i Book så att jag skulle lättare ändra men ändå har de färdiga böckerna skyddade.

2. _Book-klassen_ ska ärvas av minst tre underklasser av böcker. Förslagsvis _Roman_, _Tidskrift_ och _Novellsamling_. 

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Journal.cs#L1-L21

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Novel.cs#L1-L21

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Novellcollection.cs#L1-L21

Jag har skapat Journal,Novel och Novellcollection
Jag översätter de till engelska för att jag gillar att programmera i engelska för att det är internationellt.

De är satta till publik för att i GUI ska kunna skapa dem.
man hade kunnat sätta dem till internal och skicka variablerna till library och skapa där men det hade varit jobbat och rörigt.

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/BookType.cs#L1-L16

För att lättare veta vad för typer som fins i programmet skapade jag "BookType" som är ett enum som jag ändvänder lite överallt i programmet.
Alternativet till enumet är att hårdkodat i korden men det gör att om man behöver ändra någon behöver man söka mycken men med enymet kan man kolla alla referenser och ändra där.

3. Lösningen ska innehålla en klass kallad Library (bibliotek), som ska innehålla en lista med böcker. Listan måste vara private och andra klasser kan bara integrera med listan med hjälp av metoder. 

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L1-L217

Jag har skapat en publik klass som heter Library som har lista av books som är private.
library är Morton/ingångspunkten i libraryCore så den måste vara publik.
listan av böcker hade jag ändå satt till privat för att skydda datan och på ett kontrollerat set ändra datan.

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L80-L85

det är också därför jag skapa en ny lista med nya böcker som är en kopia av originallistan för att förhindra att man förändra originallistan (som att: lägga till/tar bort böcker eller kala metoder i boken som ändra data)

* Bibliotek-klassen ska ha minst fyra publika metoder:

  4. En för att lägga till en bok i listan 
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L95-L110

  jag har metod AddBook(en book) som kollar att boken innehåller en title och writer. sen om den är ok så lägger jag den i listan(books).
  jag kollar för att jag inte vill fylla upp med böcker som inte har något namn eller författare.
  nästa steg som man kan tar är att kontrollera att det är ok namn men jag saknar tid ock kunskap för att skapa den kollen.
  men jag skulle kolla på att kunna ändvända mig av regex och se om den kan blir uppsatt på ett bra set.

  5. En för att lägga till flera böcker samtidigt (en lista med böcker) 

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L119-L130

  jag har skapat en till klass AddBook(flera books) som jag loppa igenom listan och skickar till AddBook(en book)
  anledningen jag kallar på den andra metoden är att på ett ställe kontrollera att en book är giltig inställer att sprida ut det.
  det gör att jag kan enkelt kan förändra hur jag kolla om boken är giltig.

  6. En för av att skriva ut alla böcker i biblioteket. 
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L56-L69

  jag har slått i hopp denna med punkt 7 för att när man söker på "" så får man alla.
  det gör jag för att man kan få hela listan när man kolla efter en tom sträng.
  det gör att jag kan minska på metodena och kan återanvända kord.

  (jag kar skapat en metord som lämna ut (ny) lista av oginalet för att 100% ska klara denna punkt.)
https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L77-L86

  7. En för att söka bland böckerna i bokhyllan med en given sträng (indata) 

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L56-L69

  när jag skapade mig av GetListOfBooksSearch ville jag ändvända mig av linq så jag rådfråga mig av https://docs.microsoft.com/en-us/dotnet/api/system.linq.

  jag hade skapat en metod i book som jag få bara de info som jag vill söka på i en sträng som jag tar "ToLower" och hämta de som innehåller sökordet med hjälp av Contains med hjälp av linq.

  jag skulle kunna ta och skapa en tom lista av böcker och loppat listan av böcker (i biblioteket)
  för att kolla om det innehåller liknar med Contains

  linq är kraftig verktyg som inte är supersvår att ändvända sig av och jag tycker att den är talande av vad den gör nar man läser korden.
  
8. Varje underklass till Book: tidskrift, roman, novellsamling; ska ha en egen override av ToString metod som ska användas när alla böcker i biblioteket listas. Den metoden ska ge tillbaka olika strängar beroende på vilken klass det är. 

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Journal.cs#L16-L19

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Novel.cs#L16-L20

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/Novellcollection.cs#L16-L19

jag gjorde boken till en abstract klass med abstract metoden ToString() för att tvinga sub klasserna att har ToString().
jag gjorde att metoden var abstract för att de skulle automatik länka ihop.
den andra teknik är i book tostring ändvända sig av en switch som man kolla vilken sub klass den är och kasta om den till den räta typ och kalla på dennas tostring.
man skulle kunna kolla vilken typ det är trollvisa genom att ändvändas sig av typeof(). jag kan fuska för jag har en propety i book som jag säger vilken type den är.

* Användaren ska genom en konsolmeny kunna:

  I stora hela ändvänder jag mig av meny klasen som skapa och kontrollera GUI.
  i menyerna har den kontroll vad användaren kan göra.

  9. Lägga till nya böcker i biblioteket
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryConsole/Menu.cs#L99-L199

  min upplägg var att göra att användaren ska kunna kontrollera med pilkagentenar och att man ska uppdatera när man trycker och förändra på bilden.
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryConsole/TwoDIndex.cs#L1-L19
  
  jag skapa mig en stöd kals (TwoDIndex) för att jag skulle hjälpa mig att veta vart man är i och editera.
  jag är fortfarande osäker om den bodde vara en klass eller struct.
  jag andväder mig att en arey innan jag skapade kalssen men den var rörig att man måste vete att [0] är x och at [1] är y.
  därför skapade jag klassen så att texten ska vara så lät läst som möglig.
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/BookMapp/BookTemple.cs#L1-L109

  jag skapa en lista av BookTemple för att jag ska lätt ska editera på och den har några metoder som inte passa i en book(klassen) 

  mina andra idéer som jag hade var att göra book mer öppen men jag gillade inte idén den tredje var att ändvända mig av en 2d arrey men den sändes väldigt rörig att hålla koll på vad som är vad i arreyen.

  jag vill få hur många typer av böcker som finns.
  jag har den innan loopen för att inte tar mer kraft för att den inte kommer att förändra sig.

  sedan starta jag av do while loopen.
  jag gillar att ändvända mig av do loppen när man jobbar med menyer för att jag vill göra den en gång innan jag kolla om jag vill göra om den.
  det är ingen stor skillnad mellan do och while i detta ställe och kan enklast brytas ut.

  jag vill kolla att jag är inne i godkänt index (så att jag inte är innan eller efter vad man kan editera på).

  för att göra koden enklare tar jag ut referensen av den jag är och editera på inställer att ändvända mig direkt av listan.

  sen tar jag rensa och skriver ut instruktionerna och alla BookTemple med en bra grafik.

  sedan väntar korden på att användaren ska trycka på en knapp.
  jag skulle kunna ändvända mig av ReadLine istället för ReadKey men jag vill att man ska får en direkt feedback på det man gör.

  när användaren har tryckt på en knap så switchar programmet på vilken kolumn som man är på för att alla kolumner har lite olika saker som man kan göra i.
  jag ändvänder mig av en till enum för att försöka förtyda så mycket som möjligt. jag ändvänder mig innan av en int men då måste man hålla koll på vilken som är vilken.
  men det är inte heller bra att ändvända sig av för mycket enum för då kan det blir rörig i projekt struktur.

  10. Lista alla böcker i biblioteket  
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryConsole/Menu.cs#L205-L290
    
   denna har jag gjort genom att slå ihop med att man kan också söka när man har fåt listan.

  11. Söka efter en bok med ett givet namn. Boken ska matcha om det man söker efter finns någonstans i bokens titel, författarens namn eller i utgivningsåret och ska inte vara känsligt för stora eller små bokstäver.
  
  https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryConsole/Menu.cs#L205-L290

  jag har gjort detta på att man få listan.
  sen när man trycker på en knap så säker den på vad man har skrivit och uppdatera listan.

  jag gjorde att man får feedback på vad som man har träfat på.
  men jag ångra lite att jag gjorde för att korden blir krångligare genom att den splittra på flera ställen och klistra ihop igen men färga de till en annan färg.
(jag har förändrat den så att den ska vara mer tydlig)
  jag gillar den grafisk men den krånglar till koden.
  
12. Varje bok som användaren sparar i Biblioteket ska vara ett eget objekt av typen Book.

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L34

alla böcker som sparas i libery är av typen book och den sparas i en fil CSV och kan blir återskapad till sin typ av book (därför har jag att den spara vilken typ den är)

13. När programmet startar ska en färdig konfigurerad lista av minst 5 böcker av olika typer från början finnas i biblioteket.

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L40-L43

https://github.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/blob/8677f499ec61c828f1923894cb7e772f0986b536/LibraryCore/Library.cs#L182-L195

När man skapa en obj av Library så laddar den in böcker ifrån en fil och om den inte har 5 böcker så genererar den upp till 5 böcker av olika typer med hjälp av faker.

däremot finns det inget delete medod så man få gå till filen och delete manual.

## sammanfattning

jag tycker att jag är nöjt med programmet jag som jag har skapat. den är inte perfekt men det beror på att jag ville har lite häftigare GUI.

De beslut som har gjort att korden blir krångligare är: 
1. att jag ville ändvända av piltangenterna i menyerna,
2. att jag ville att man ska få feedback när man söker och att den ska uppdatera när man söker automatisk.
3. att jag ville att man ska kunna editera hela raden och flera stycken samtidigt 

korden skulle ha varit renare om jag:
1. hade bett om en siffra i menyerna
2. att man skulle bara få när man har sökt på ordet.
3. att man få en sak efter varandra när man vill lägga in böckerna.

men jag gillrade att göra utmaningen med de beslut jag gjorde och jag gilla också GUIn jag är ok till nöjd med korden nu när jag har förenklat dennas strukturen.

---
# Planerande
### innehållsförteckning För Planerande
1. Kord Strandad
2. Kravspecen
3. Kord Struktur
4. Bygget av Korden

## Kord Strandad

### Projekt
Jag Kommer att avvända mig av två grundläggande projekt:
#### LibraryConsole
Kommer att innehålla alla kord som hantera UI och menyer.
#### libraryCore
Kommer att innehålla kärnan av alla datahanteringar.

Jag har splitat dessa för att lättare förstå vad som ar vad i korden och att inte blanda dem.

### Namn
Jag Kommer att gå efter standaren med att har stor bokstav på alla utom felt Variabler.
Detta är för att underlätta att förstå vad som är vad.

### Metod Kommentar
Alla Publika metoder måste ha en kort Kommentar vad den gör, vad den vill har input och vad den har utdata.
Detta är för att lättare veta vad metoden ska och gör.

### Metoder VS Propety
Jag har blivit mer av att jag avvänder mig av metoder för att jag tycker att jag har mer kontroll på korden.
Jag gör detta för att

### Metod (Class ob) VS Metod (Variabler av den klassen) //Detta är när man ska skapa nya obj och lägga in i en lista
Jag är mer på att skicka in variabler till metoden och att den kontrollera att det stämmer istället för att den ska skapa i GUI och sicka till metoden.
men det gäller inte om det är många variabler som behövs skickats (CA: 3–4 och mer).
om man ska skapa en lista går det bra att skicka en lista obj

efter projekten så gillar jag mer att skicka obj till metoden.

### Enum
Jag kommer att bygga mina menyer från enum och kommer att lägga dem i Meny klassen eller om det blir för många kommer jag att skapa en statisk klass som har alla enum i.
detta är för att enkelt veta vart enumen är och att det ska blir enklare att lägga till nya options i menyerna.

**OBS** detta gäller inte för enumet som säger till vilka typer av böcker som finns den ligger i libraryCore

## Kravspecen
1. Lösningen ska innehålla klassen _Book_ med minst tre egenskaper: titel, skribent och utgivningsår. 
2. _Book-klassen_ ska ärvas av minst tre underklasser av böcker. Förslagsvis _Roman_, _Tidskrift_ och _Novellsamling_. 
3. Lösningen ska innehålla en klass kallad Library (bibliotek), som ska innehålla en lista med böcker. Listan måste vara private och andra klasser kan bara integrera med listan med hjälp av metoder. 
* Bibliotek-klassen ska ha minst fyra publika metoder:

  4. En för att lägga till en bok i listan 
  5. En för att lägga till flera böcker samtidigt (en lista med böcker) 
  6. En för av att skriva ut alla böcker i biblioteket. 
  7. En för att söka bland böckerna i bokhyllan med en given sträng (indata) 
  
8. Varje underklass till Book: tidskrift, roman, novellsamling; ska ha en egen override av ToString metod som ska användas när alla böcker i biblioteket listas. Den metoden ska ge tillbaka olika strängar beroende på vilken klass det är. 
* Användaren ska genom en konsolmeny kunna:

  9. Lägga till nya böcker i biblioteket
  10. Lista alla böcker i biblioteket 
  11. Söka efter en bok med ett givet namn. Boken ska matcha om det man söker efter finns någonstans i bokens titel, författarens namn eller i utgivningsåret och ska inte vara känsligt för stora eller små bokstäver.
  
12. Varje bok som användaren sparar i Biblioteket ska vara ett eget objekt av typen Book.
13. När programmet startar ska en färdig konfigurerad lista av minst 5 böcker av olika typer från början finnas i biblioteket.

### Kommentarer av Kravspecen
1 till 7 känns straight forward.
Jag är inte överlycklig av namnet i 3 "Library" den känns som att den är för bred namn på klassen (Jag kanske gillar den mer senare).
Jag ser att "Library" är ingångspunkten i min "libraryCore" (vilket kommer att vara 1–8).

en fråga som jag ställer är om att 4 och 5 kan vara samma metod.
Men jag tror att jag behåller de separerat för att i "Fler böcker" loppar böckerna och kalla på "En bok" då kan jag åter ändvända kord och det ser renare ut.

8 hoppas jag att boken klassen är tillräckligt smart att videbefordra till sin sub klass. Annas får jag skapa en switch som gör det åt mig.

9 fundera jag att lösa genom att skapa en meny som man har | Skribent |Titel| Type |utgivnes år| där i type kan ändvända upp/ner piltangent för att byta typ och sidor pil för att byta vilken position som man editerar i och om man inte i type ska upp/ner byta vilken bok man vill editera (Om man har alla info som man ska har).

Fundera på att slå ihop 10 och 11 för att få alla om det inte man inte har något i sökningen.
11 jag vill uppdatera listan när man skriver om jag har tid ska jag mankera vad träffar/träffas är.
Jag fick svaret: "Så länge funktionskraven är uppfyllda så kan du lösa det lite hur du vill:)"

12 jag är osäker vad som menas med denna.
Jag misstänker att man bara har en lista som är klassen bok.
Jag fick svaret: "Om du vill spara till fil så behöver du ju särskilja underklasserna på något sätt men annars bara en lista med book ja."

13 Jag kommer att lada in böker från en fil men är den listan minder en 5 kommer jag att skapa nya böcker för att komma till minst 5 böcker.

### Mokup

![alt text](https://raw.githubusercontent.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/master/Images/ClassDiagram.png?token=AQ5XMIQCIYWXUYYRFZ6DJ527SWEOG)
![alt text](https://raw.githubusercontent.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/master/Images/MainMenyConsole.png?token=AQ5XMIRGPJK2VQVVCNOKRIK7SWE5G)
![alt text](https://raw.githubusercontent.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/master/Images/ListAndSearchingEmtyConsole.png?token=AQ5XMIQJ7O5UR7LH2QZCLHC7SWEVG)
![alt text](https://raw.githubusercontent.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/master/Images/ListAndSearchingwhitSearchConsole.png?token=AQ5XMIQG4D3ZDRKXCKOTWK27SWE2C)
![alt text](https://raw.githubusercontent.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/master/Images/AddOneConsole.png?token=AQ5XMIU6I67WYPOVOCV2JRK7SWFAQ)
![alt text](https://raw.githubusercontent.com/BY-SUVNET-OOP-2020/biblioteket-95joaols/master/Images/AddMoreConsole.png?token=AQ5XMISI2PELEMH75GZE7OK7SWFDY)



## Kord Struktur
---
# Genomförande
## Bygget av Korden
Jag Starta i kärnan av programmet föst för att den kommer att förnedras minst och att alt byker på den.

Jag skapa en mapp som jag kalla book för att lägga mina books klass och subklasser.
Jag lägger även min Enum Som berätta vilka typer av böcker för att hålla alt samma

## LibraryCore


### Book
Den fösta klass jag bygger är Book.
Den setter jag till abstract för att förhindra att man skapa direkt av den i misstag.
Sen setter jag alla variabler (Titel,Writer,Publication) till att inte vara abstract för att minska på koden.
jag setter dem till att vara public (med protected set) för att de är entiteter som jag ska visa i GUI men den vet inte på vilket set.

Jag skapa en abstract override ToString() för att jag ska underlätta för mig när jag skapa sub klasser så att jag inte ska behöva ändvända en switch.

### Novel,Journal,Novellcollection SubClassena till Book
Jag Skapa sub klasserna till book och implementera men jag låter "throw new NotImplementedException();" vara kvar för att jag är fortfarande i planering stadiet.

### BookType Enumet
Jag skapa Enumet BookType för att lätt ska se vilka subclasser till book finns jag setter den att vara int för att underlätta när man loopa igenom den i menyerna.
Jag fyller på men de skapade subklasserna

### Library klassen, Den fösta större klass
Nu när jag har skapat de entiteterna tar jag och försätter med Library som är motorn för kärnan.
När jag skapa listan stöter jag med ett litet problem med att namnet på mappen är samma namn på klassen så jag ändra på mappen till BookMapp.

Jag Lägger till de tomma metoder som jag tror att jag behöver i Library och lägger en kometerna med vad jag förvänta mig av mig

### Påfyllnad av metoder i books typerna
Nu gå jag tillbaka till typerna.
jag funderar att jag kommer behöver tre metoder som returnera strängar om detta objekt.
1. ToString som ska vissa upp det på ett bra sätt.
2. Searchable som ska returnera alt som ska sökas på.
3. CSVFormat så att jag ska lätt kunna spara obj.

jag funderade att Serialization men jag insåg att den tekniken inte fugerad om jag ändvänder mig av abstractklass. så jag kör på altetivet CSV.

Jag Lägger ToString i sub klasser för att jag ska kunna göra texten snyggare.
men CSVFormat och Searchable inte behöver vara stora skillnader mellan sub klasserna så lägger jag den i huvudklassen.

### AddBook
Nu när kärnan är klar så fortsätter jag till att man ska kunna lägga till nya böcker (i LibraryCore)

Föst kollar jag att den obj är ok och att det fins ett obj.
Sedan kalla den på att spara metoden

Jag gör att man kan lägga till flera böcker samtidigt.

### LibraryConstructor
jag skapa mig en constructor som ska ladda in från en fil men är listan mindre en 5 ska den generera upp till 5 böcker.

### Save
Jag Gör att man kan spara i en CSV genom att loopa igenom lostan av böcker och läger innehåller i en lista som vi spara i en fil.
För att spara behöver jag en fillvägen som jag skapa en const string i klassen

### GenerateNewBook
För att effektivt ska kunna testa de metoder vi har skapat tar jag och försätter med GenerateNewBook.

För att slumpa ut vilken typ av bok så måste jag veta hur många typer jag har då ändvänder ett kod som jag ändvänder i ett annat program som blir: (BookType)random.Next(0, Enum.GetValues(typeof(BookType)).Length);
Jag kan inte lägre hitta källan men den liknar https://stackoverflow.com/questions/1799370/getting-attributes-of-enums-value

För att enkelt få namn på boken så ändvänder jag mig av Faker biblioteket

Jag vill på ett enkelt set slumpa datumet så jag tar hjälp av: https://stackoverflow.com/questions/194863/random-date-in-c-sharp

Nu är det klar nu är det tid att:

### Fösta Testande
Det Fugerade bra men jag ändvänder fel typ av faker när jag vil har titel. jag såg att faker har en random dattime så jag tog bort den andra.
Jag hittar inte den rätta typen av slump så jag väljer random bokstäver

### Load
Jag ser att jag kommer att behöva samma switch som i generade så jag lägger den i en privat metod.
Jag läser in alla rader från Filen sen kör jag en if-sats där jag kollar att jag kan få en siffra och att jag kan få ett datum.
sedan skapa jag korden i de nya metoderna.
Ser när jag testade såg jag att jag hade ändvänder brake när jag skulle ändvända av continue.

### GetListOfBooksSearch Sista LibraryCore metoden
Jag har en idé att jag vill ändvända mig av Linq så jag rådfråga mig av https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=netcore-3.1 för att veta att jag sätter den upp korrekt.
I slutet ser den ut: return books.Where(book => book.Searchable().ToLower().Contains(search.ToLower())).ToList();

Låt oss testa om den fungera som den ska.
Den fungera när jag kör tom och när jag kör men något.
Nästa fråga är om jag ska skicka tillbaka strängar eller objektet.
När man bara ändvänder konsolen så är strängar bättre men i andra program typer är objektet bättre (Så länge den är read only).
jag avvakta med frågan och låter den retirera obj.

---

## LibraryConsole
nu är det dags att böja göra menyerna.

### Meny
Jag börja skapa malen för vad som ska finnas för metoder
Jag börja med ScrollableAndSelectableMeny som ska bygga typer som Main meny.
sedan lägger jag till AddBooksMeny som gör att man kan lägga till nya böcker.
sist läger jag till SearchableMeny som gör att man söker bland böckerna.

### MenyEnum
Jag andvender mig av enum när jag bygger mina Main meny för att jag tycker att det förenklar processen och är lättare att lägga till eller ta bort nya options.
jag ändvänder mig tekniken som liknar https://stackoverflow.com/questions/1799370/getting-attributes-of-enums-value.

jag lägger GetEnumDescription i En klass som kommer att vara en verktygslåda.

### ScrollableAndSelectableMeny
Jag Skapa en int som håller koll på vilken index som vi är på och jag skapa en till för att hålla koll på maxindex är.
Jag skapa en do while loop för att jag alltid vill köra den en gång.

Jag börjar att Clear konsolen för att kunna uppdatera utan att användaren marker det.

Sen tar jag skapa en foreach som ska lista upp alla options.
men jag kan inte översöta T till en int så jag får byta till en for loop.
efter en del problem so tror jag att jag har en lösning som gör att jag kan lista T(enum).
låt os testa om det fugerad.
Den fugerad.
nu ska jag lägga till så att jag ser vilken man är på.
Det gör jag genom att ändra på bakgrundsfärgen och läger en pil framför.
nu ska jag göra att man kan byta vilken option man är på.
Jag har Gjort att man kan öka och minska och att man kan välja.
Fundera att lägga ut till en annan metod.
När jag testa märker jag att enumet är minsta överst och största underst vilket gör att det blir inverterad men det är bara att ändra på.
nu när jag testade menyn så marker jag att den blinkar när den uppdatera sig.
Jag få lägga en loop som gör att den bara uppdatera sig när den behövs.

Jag Slängde ut och skapade ListEnumWhidSelect och GetIndexWithKey
GetIndexWithKey får jag vilken key som blev ner tryckt och den ändra vilket index som gäller. 

### Program main
nu går jag tillbaka och lägger alt i en while loop.
jag skapa switchen för enumet. jag försätter med att färdiggöra exit.
Jag rensa listan och skriver Goodbye
jag gör att jag kan kalla på SearchableMeny.

### SearchableMeny
Först försöker jag upp variablerna sedan så tar jag och stata loopen.
jag hämtar alla böcker som matchar med sökningen.
sedan vill att min text ska vara prydlig so jag Clear konsolen.
Skriver ut vad man söker på denna och lista jag upp listan (kommer att bygga om så att jag visa vad som mastade.)
sen vill jag att användaren ska kunna söka genom att tryga på en knapp.
sen kalla jag på Usersearch med knapptryckningen och ref search.
men jag får göra att man limitera vilka knappa som är ok.
en idé är att använda mig av en lång if sats som jag inte gillar.
jag googlade och hittade https://stackoverflow.com/questions/40360199/check-readkey-only-for-letters-alphabet-in-string
det var simplare än vad jag trodde.

nu vill jag att det ska se träffen var.
Jag splittra på stringen på det jag söker på.
sen kissar jag tillback men träffen på sökområde.
men jag makter att om jag skrev 20 så försvann den sista 20 i 2020
så jag skapade en loop som kolla om det ska finnas en eller flera sökning ord.

Men jag vill inte ett Title,weiter eller Publication ska markeras så jag få spilta ut dem.
Nu är det ganska mycken kord i metoden so jag får bryta ut och kommentarer.
Efter mycket bug test fungera det nu förutom att alla text blir till loercase.

### BookTemple
För att förbereda mig av AddBooksMeny så skapa mig av BookTemple som liknar book men den har inga resektioner till att bli ändrad.
alternativet till BookTemple är att lägga till många metoder (eller låsa upp klasen vilket jag inte vill). 

För att på ett letare set att bara sätta ett nummer så skapade jag metoden SetASpecialNumberInDateTime som ändra DateTime till CharArray för att satta en speciell till x som användaren vill sen omvandla jag den till tre stringar och skapa en ny DateTime av stringarna.

### AddBooksMeny
föst deklarerar jag mina variabler.
jag kommer att behöva vart jag är(editIndex) och lista jag arbeta med(bookTemples) som jag börja med att lägga en tom i.

Sedan vill jag ha ut vad som är maxindex i BookType(enum)

Nu starta vi loopen.
vi kolla så att vi inte är utanför något index.
vi tar ut vilken som är den nuvarande book som vi editera.
rensa all text och fyller på den med alla rader.

sedan väntar vi på att användaren ska trycka på en knap.
om vi är på colum 0 så ändrar vi vilken typ boken kommer att ha.
efter så kollar jag om man är i datum edit.
sedan kollar jag om man är i Title eller writer
när man kan förflyttar sig till nästa rad

Nu är de mesta klart men nu är det tid för att kollar efter fel och debugar och lägga ut instruktion till användaren.
