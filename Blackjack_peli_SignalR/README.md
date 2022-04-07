# SignalR Chat + Blackjack

Tässä tehtävässä luotiin BlackJack peli sovellus useammalle pelaajalle käyttäen ASP.NET ympärisöä hyödyksi. Alla tarkempia kuvauksia vaatimuksisa mitä sovelluksessa vaadittiin.
Tässä toteutuksessa on kaikki vaatimukset tehty lukuunottamatta korttien piirtämistä näytölle
(ne näkyvät sovelluksessa vain numeroina). Lisäksi myös muita pieniä viilauksia olisi sovelluksen sujuva toiminta vaatinut.

## Tehtävät

### 1. Luo SignalR Chat-sovellus Blazor-tekniikalla (1p)

Seuraa ohjedokumenttia (SignalR with Blazor) ja luo chat-sovellus käyttäen Blazor WASM -tyyppistä sovellusta, joka palvellaan (host) ASP.NET Core -sovelluksessa. Lisää sovellukseen SignalR-tekniikkaa hyödyntäen chat-toiminnot.

Muokkaa ChatHub ja client-sovellus kommunikoimaan siten, että ChatHub:n SendMessage-metodi ottaa vain yhden parameterin vastaan. Parametrissä tulee pystyä välittämään tiedot: 
- user (string), kuka viestin lähetti
- message (string), viestisisältö
- ts (DateTime), aikaleima milloin viesti lähetettiin

Chat:ssä yhden käyttäjän kirjoittama viesti menee kaikille muille sovelluksessa aktiivisessa yhteydessä oleville käyttäjille. Kirjoitettu viesti tulee myös kirjoittajalle itselleen näkyviin. 

### 2. Lisää Blackjack-pelille oma SignalR-hub (1p)

Mallinna BlackjackHub-niminen SignalR Hub-luokka. Luokassa on toiminnot:
- Ready, pelaaja ilmoittaa nimensä ja olevansa valmis erään
- Hit, pelaaja haluua uuden kortin, metodi palauttaa pelaajalle yhden arvotun kortin korttipakasta
- Stay, pelaaja ei halua enää kortteja 
- Muut pelaajat näkevät kaikki mukana olevat pelaajat sekä heidän viimeisimmän toimintonsa.

Kun kaikki pelaajat ovat päättänee etteivät ota enää kortteja, lisätään voittajalle yksi voittopiste ja kerrotaan kierroksen tulokset kaikille pelaajille.

### 3. Luo käyttöliittymä Blackjack-pelille (1p)

Käyttäjä voi ilmoittaa nimensä ja olevansa valmis. Kun kaikki mukanava olevat käyttäjät ovat valmiita, peli alkaa.
Pelin alkaessa kaikille pelaajille jaetaan kaksi korttia.

Pelaaja voi alku korttien jaon jälkeen päättää ottaa vielä kortteja (hit) tai pysyä saamissaan korteissa (stay).
Pelaaja, joka pääsee lähimmäksi lukua 21 voittaa. Jos pelaajan korttien arvo menee yli 21, hän häviää kyseisen erän.
Pelaajat voivat tehdä toimintoja satunnaisessa järjestyksessä.

Kun kaikki pelaajat ovat päättäneet pysyä (stay) saamissaan korteissa, ilmoitetaan voitaja kaikille. Voittaja saa yhden voittopisteen.

Luo käyttöliittymä, jossa on: 
- toiminnot pelaajalle
- paikka pelaajan korttien näyttämiseen
- paikka pelin pistetilanteelle
- paikka pelissä oleville muille pelaajille sekä jokaisen pelaajan statukselle (ready, hit, stay) pelaajan viimeisimmän toiminnon mukaan.

### 4. Mallinna korttipakka sekä kortin UI (1p)

Mallinna vakio 52-kortin korttipakka. Hyödynnä Sam Jenkinsin tekemää blogia https://samjenkins.com/blog/2013/04/20/deck-of-cards-in-c/.

Laajenna korttiluokkaan (Card class) toimintoja muokkaamatta varsinaista korttiluokkaa: 
- tieto kuinka kortti "piirretään" käyttöliittymään. Hyödynnä Unicode-merkkejä https://en.wikipedia.org/wiki/Standard_52-card_deck. 
- Blackjack-sääntöjen mukainen kortin arvo.

Lisää `List<Card>` -tyyppiselle objektille metodi (extension method), joka palauttaa Blackjack-sääntöjen mukaisen korttien arvon.

Numerokortit 2 - 10 ovat lukunsa arvoiset, kuvakortit (J, Q, K) ovat kukin 10 pisteen arvoiset. Ässä on joko 1 tai 11 riippuen pelaajan muiden korttien arvojen summasta.

### 5. Yhdistä kaikki komponentit toimivaksi sovellukseksi (1p)

Yhdistä kaikki komponentit toimivaksi kokonaisuudeksi. Sovelluksessa on chat-ominaisuus ja Blackjack-peli.
Mallinna tietorakenne, joka pitää kirjaa pelin tilanteesta. Tietorakenne voi olla muistinvarainen, joka pysyy tallessa niin kauan kuin palvelinsovellus on käynnissä. Tietoja ei tarvitse tallentaa pysyväismuistiin.

