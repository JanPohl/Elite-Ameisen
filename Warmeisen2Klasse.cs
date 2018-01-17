using AntMe.Deutsch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.Warmeisen2
{
    /// <summary>
    /// Diese Datei enthält die Beschreibung für deine Ameise. Die einzelnen Code-Blöcke 
    /// (Beginnend mit "public override void") fassen zusammen, wie deine Ameise in den 
    /// entsprechenden Situationen reagieren soll. Welche Befehle du hier verwenden kannst, 
    /// findest du auf der Befehlsübersicht im Wiki (http://wiki.antme.net/de/API1:Befehlsliste).
    /// 
    /// Wenn du etwas Unterstützung bei der Erstellung einer Ameise brauchst, findest du
    /// in den AntMe!-Lektionen ein paar Schritt-für-Schritt Anleitungen.
    /// (http://wiki.antme.net/de/Lektionen)
    /// </summary>
    [Spieler(
        Volkname = "Elite-Ameisen",   // Hier kannst du den Namen des Volkes festlegen
        Vorname = "Jan",       // An dieser Stelle kannst du dich als Schöpfer der Ameise eintragen
        Nachname = "Pohl"       // An dieser Stelle kannst du dich als Schöpfer der Ameise eintragen
    )]

    /// Kasten stellen "Berufsgruppen" innerhalb deines Ameisenvolkes dar. Du kannst hier mit
    /// den Fähigkeiten einzelner Ameisen arbeiten. Wie genau das funktioniert kannst du der 
    /// Lektion zur Spezialisierung von Ameisen entnehmen (http://wiki.antme.net/de/Lektion7).
    [Kaste(
        Name = "ZuckerSammler",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = 2,                // Tragkraft einer Ameise
        ReichweiteModifikator = 0,          // Ausdauer einer Ameise
        SichtweiteModifikator = -1           // Sichtweite einer Ameise
    )]
    [Kaste(
        Name = "ApfelSammler",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = 0,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = 2,                // Tragkraft einer Ameise
        ReichweiteModifikator = -1,          // Ausdauer einer Ameise
        SichtweiteModifikator = -1           // Sichtweite einer Ameise
    )]
    [Kaste(
        Name = "Verteidiger",                  // Name der Berufsgruppe
        AngriffModifikator = 2,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = 2,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 0,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = -1,          // Ausdauer einer Ameise
        SichtweiteModifikator = -1           // Sichtweite einer Ameise
    )]
    //[Kaste(
    //    Name = "Scout",                  // Name der Berufsgruppe
    //    AngriffModifikator = -1,             // Angriffsstärke einer Ameise
    //    DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
    //    EnergieModifikator = -1,             // Lebensenergie einer Ameise
    //    GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
    //    LastModifikator = -1,                // Tragkraft einer Ameise
    //    ReichweiteModifikator = 0,          // Ausdauer einer Ameise
    //    SichtweiteModifikator = 2           // Sichtweite einer Ameise
    //)]
    //[Kaste(
    //    Name = "WanzenJäger",                  // Name der Berufsgruppe
    //    AngriffModifikator = 2,             // Angriffsstärke einer Ameise
    //    DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
    //    EnergieModifikator = 2,             // Lebensenergie einer Ameise
    //    GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
    //    LastModifikator = -1,                // Tragkraft einer Ameise
    //    ReichweiteModifikator = -1,          // Ausdauer einer Ameise
    //    SichtweiteModifikator = -1           // Sichtweite einer Ameise
    //)]
    public class Warmeisen2Klasse : Basisameise
    {
        //private Zucker zucker = null;
        //private Obst obst = null;
        //private int x = 0;
        //private int y = 0;
        private Bau bau = null;
        private Spielobjekt ZielOptimized = null;
        private bool registered = false;
        private bool registeredapfel = false;
        //private bool registeredwanze = false;
        //private WanzenTicket ticketwanze = null;
        private Ticket ticket = null;
        private ApfelTicket ticketapfel = null;
        #region Kasten

        /// <summary>
        /// Jedes mal, wenn eine neue Ameise geboren wird, muss ihre Berufsgruppe
        /// bestimmt werden. Das kannst du mit Hilfe dieses Rückgabewertes dieser 
        /// Methode steuern.
        /// Weitere Infos unter http://wiki.antme.net/de/API1:BestimmeKaste
        /// </summary>
        /// <param name="anzahl">Anzahl Ameisen pro Kaste</param>
        /// <returns>Name der Kaste zu der die geborene Ameise gehören soll</returns>
        public override string BestimmeKaste(Dictionary<string, int> anzahl)
        {
            if (anzahl["Verteidiger"] < 21)
            {
                return "Verteidiger";
            }
            else if (anzahl["ApfelSammler"] < 16)
            {
                return "ApfelSammler";
            }
            //else if (anzahl["Scout"] <= 3)
            //{
            //    return "Scout";
            //}
            else
            {
                return "ZuckerSammler";
            }








        }

        #endregion

        #region Fortbewegung

        /// <summary>
        /// Wenn die Ameise keinerlei Aufträge hat, wartet sie auf neue Aufgaben. Um dir das 
        /// mitzuteilen, wird diese Methode hier aufgerufen.
        /// Weitere Infos unter http://wiki.antme.net/de/API1:Wartet
        /// </summary>
        public override void Wartet()
        {



            if (!registeredapfel && !registered && Kaste == "Verteidiger")
            {
                //Ticketmanager.Instance.RegisterAmeise(this);
               // registered = true;
                Apfelticketmanager.InstanceApfel.RegisterApfelAmeise(this);
                registeredapfel = true;
            }

            if (Kaste == "Verteidiger")
            {
                ticketapfel = Apfelticketmanager.InstanceApfel.GetApfelTicket();
               // ticket = Ticketmanager.Instance.GetTicket();
            }


            if (ticketapfel == null && Kaste == "Verteidiger")
            {
                DreheUmWinkel(Zufall.Zahl(-30, 30));
                GeheGeradeaus(100);
            }

            if (ticketapfel != null && Kaste == "Verteidiger")
            {
                GeheZuZielOptimized(ticketapfel.Obst);
            }


            if (!registered && Kaste == "ZuckerSammler")
            {
                Ticketmanager.Instance.RegisterAmeise(this);
                registered = true;
            }

            if (Kaste == "ZuckerSammler")
                ticket = Ticketmanager.Instance.GetTicket();


            if (ticket == null)
            {
                DreheUmWinkel(Zufall.Zahl(-30, 30));
                GeheGeradeaus(100);
            }
            if (ticket != null && Kaste == "ZuckerSammler")
            {
                GeheZuZielOptimized(ticket.Zucker);
            }




            if (!registeredapfel && Kaste == "ApfelSammler")
            {
                Apfelticketmanager.InstanceApfel.RegisterApfelAmeise(this);
                registeredapfel = true;
            }

            if (Kaste == "ApfelSammler")
                ticketapfel = Apfelticketmanager.InstanceApfel.GetApfelTicket();


            if (ticketapfel == null && Kaste == "ApfelSammler")
            {
                DreheUmWinkel(Zufall.Zahl(-30, 30));
                GeheGeradeaus(100);
            }

            if (ticketapfel != null && Kaste == "ApfelSammler")
            {
                GeheZuZielOptimized(ticketapfel.Obst);
            }



            //if (!registeredwanze && Kaste == "Verteidiger")
            //{
            //    Wanzenmanager.InstanceWanze.RegisterVerteidigerAmeise(this);
            //    registeredwanze = true;
            //}

            //if (Kaste == "Verteidiger")
            //    ticketwanze = Wanzenmanager.InstanceWanze.GetWanzenTicket();


            //if (ticketwanze == null && Kaste == "Verteidiger")
            //{
            //    DreheUmWinkel(Zufall.Zahl(-30, 30));
            //    GeheGeradeaus(100);
            //}

            //if (ticketwanze != null && Kaste == "Verteidiger")
            //{
            //    GeheZuZielOptimized(ticketwanze.Wanze);
            //}

            //if (!registeredapfel && !registered && Kaste == "Scout")
            //{
            //    Ticketmanager.Instance.RegisterAmeise(this);
            //    registered = true;
            //    Apfelticketmanager.InstanceApfel.RegisterApfelAmeise(this);
            //    registeredapfel = true;
            //}

            //if (Kaste == "Scout")
            //{
            //    ticketapfel = Apfelticketmanager.InstanceApfel.GetApfelTicket();
            //    ticket = Ticketmanager.Instance.GetTicket();
            //}


            //if (Kaste == "Scout")
            //{
            //    DreheUmWinkel(Zufall.Zahl(-60, 60));
            //    GeheGeradeaus(200);
            //}




            if (bau == null)
            {
                GeheZuBau();
                bau = Ziel as Bau;
                BleibStehen();
            }

            //if (zucker != null && zucker.Menge > 0)
            //{
            //    //GeheZuZielOptimized(zucker);
            //    GeheZuKoordinate(x, y);
            //}
            //else
            //{
            //    GeheGeradeaus();
            //}
        }

        /// <summary>
        /// Erreicht eine Ameise ein drittel ihrer Laufreichweite, wird diese Methode aufgerufen.
        /// Weitere Infos unter http://wiki.antme.net/de/API1:WirdM%C3%BCde
        /// </summary>
        public override void WirdMüde()
        {


        }

        /// <summary>
        /// Wenn eine Ameise stirbt, wird diese Methode aufgerufen. Man erfährt dadurch, wie 
        /// die Ameise gestorben ist. Die Ameise kann zu diesem Zeitpunkt aber keinerlei Aktion 
        /// mehr ausführen.
        /// Weitere Infos unter http://wiki.antme.net/de/API1:IstGestorben
        /// </summary>
        /// <param name="todesart">Art des Todes</param>
        public override void IstGestorben(Todesart todesart)
        {
            if (Kaste != "ApfelSammler")
            {
                Ticketmanager.Instance.UnregisterAmeise(this, ticket);
            }
            if (Kaste != "ZuckerSammler")
            {
                Apfelticketmanager.InstanceApfel.UnregisterApfelAmeise(this);
            }
        }

        /// <summary>
        /// Diese Methode wird in jeder Simulationsrunde aufgerufen - ungeachtet von zusätzlichen 
        /// Bedingungen. Dies eignet sich für Aktionen, die unter Bedingungen ausgeführt werden 
        /// sollen, die von den anderen Methoden nicht behandelt werden.
        /// Weitere Infos unter http://wiki.antme.net/de/API1:Tick
        /// </summary>
        public override void Tick()
        {
            if (ZielOptimized != null)
            {
                int distance = Koordinate.BestimmeEntfernung(this, ZielOptimized);
                if (distance < Sichtweite)
                {
                    GeheZuZiel(ZielOptimized);
                    ZielOptimized = null;

                }
                
            }

            if (Reichweite - ZurückgelegteStrecke - 20 < EntfernungZuBau)
            {
                GeheZuBauOptimized();
            }

            //if (AktuelleLast > 0 && GetragenesObst == null)
            //{
            //    SprüheMarkierung(Richtung + 180, 50);
            //}
        }

        #endregion

        #region Nahrung

        /// <summary>
        /// Sobald eine Ameise innerhalb ihres Sichtradius einen Apfel erspäht wird 
        /// diese Methode aufgerufen. Als Parameter kommt das betroffene Stück Obst.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:Sieht(Obst)"
        /// </summary>
        /// <param name="obst">Das gesichtete Stück Obst</param>
        public override void Sieht(Obst obst)
        {


            //if (Kaste == "ApfelSammler")
            //{
            Apfelticketmanager.InstanceApfel.ReportFruit(obst);
            //}

        }

        /// <summary>
        /// Sobald eine Ameise innerhalb ihres Sichtradius einen Zuckerhügel erspäht wird 
        /// diese Methode aufgerufen. Als Parameter kommt der betroffene Zuckerghügel.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:Sieht(Zucker)"
        /// </summary>
        /// <param name="zucker">Der gesichtete Zuckerhügel</param>
        public override void Sieht(Zucker zucker)
        {
            if (Kaste == "ZuckerSammler")
            {
                Ticketmanager.Instance.ReportSugar(zucker);
            }

            //this.zucker = zucker;
            ////SprüheMarkierung(1000, 70);

            ////int distanz = Koordinate.BestimmeEntfernung(this, bau);
            ////int richtung = Koordinate.BestimmeRichtung(bau, this);

            ////float angle = ((float)richtung / 360) * ((float)Math.PI * 2);
            //this.x = BestimmeX(zucker);
            //this.y = BestimmtY(zucker);



            //if (Ziel == null && ZielOptimized == null && Kaste == "Sammler")
            //{
            //    GeheZuZiel(zucker);
            //}
        }

        /// <summary>
        /// Hat die Ameise ein Stück Obst als Ziel festgelegt, wird diese Methode aufgerufen, 
        /// sobald die Ameise ihr Ziel erreicht hat. Ab jetzt ist die Ameise nahe genug um mit 
        /// dem Ziel zu interagieren.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:ZielErreicht(Obst)"
        /// </summary>
        /// <param name="obst">Das erreichte Stück Obst</param>
        public override void ZielErreicht(Obst obst)
        {

            if (Kaste == "ApfelSammler")
            {
                BrauchtNochTräger(obst);
                Nimm(obst);
                GeheZuBauOptimized();
            }

            if (Kaste == "Verteidiger")
            {
                BleibStehen();
                GeheGeradeaus(20);
                DreheUmWinkel(45);
            }

        }

        /// <summary>
        /// Hat die Ameise eine Zuckerhügel als Ziel festgelegt, wird diese Methode aufgerufen, 
        /// sobald die Ameise ihr Ziel erreicht hat. Ab jetzt ist die Ameise nahe genug um mit 
        /// dem Ziel zu interagieren.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:ZielErreicht(Zucker)"
        /// </summary>
        /// <param name="zucker">Der erreichte Zuckerhügel</param>
        public override void ZielErreicht(Zucker zucker)
        {
            Nimm(zucker);
            GeheZuBauOptimized();
        }

        #endregion

        #region Kommunikation

        /// <summary>
        /// Markierungen, die von anderen Ameisen platziert werden, können von befreundeten Ameisen 
        /// gewittert werden. Diese Methode wird aufgerufen, wenn eine Ameise zum ersten Mal eine 
        /// befreundete Markierung riecht.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:RiechtFreund(Markierung)"
        /// </summary>
        /// <param name="markierung">Die gerochene Markierung</param>
        public override void RiechtFreund(Markierung markierung)
        {
            //if (Kaste == "Verteidiger" && Ziel == null)
            //{
            //    GeheZuZielOptimized(markierung);
            //}


        }

        /// <summary>
        /// So wie Ameisen unterschiedliche Nahrungsmittel erspähen können, entdecken Sie auch 
        /// andere Spielelemente. Entdeckt die Ameise eine Ameise aus dem eigenen Volk, so 
        /// wird diese Methode aufgerufen.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:SiehtFreund(Ameise)"
        /// </summary>
        /// <param name="ameise">Erspähte befreundete Ameise</param>
        public override void SiehtFreund(Ameise ameise)
        {

        }

        /// <summary>
        /// So wie Ameisen unterschiedliche Nahrungsmittel erspähen können, entdecken Sie auch 
        /// andere Spielelemente. Entdeckt die Ameise eine Ameise aus einem befreundeten Volk 
        /// (Völker im selben Team), so wird diese Methode aufgerufen.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:SiehtVerb%C3%BCndeten(Ameise)"
        /// </summary>
        /// <param name="ameise">Erspähte verbündete Ameise</param>
        public override void SiehtVerbündeten(Ameise ameise)
        {
        }

        #endregion

        #region Kampf

        /// <summary>
        /// So wie Ameisen unterschiedliche Nahrungsmittel erspähen können, entdecken Sie auch 
        /// andere Spielelemente. Entdeckt die Ameise eine Ameise aus einem feindlichen Volk, 
        /// so wird diese Methode aufgerufen.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:SiehtFeind(Ameise)"
        /// </summary>
        /// <param name="ameise">Erspähte feindliche Ameise</param>
        public override void SiehtFeind(Ameise ameise)
        {
            if (Kaste == "Verteidiger")
            {
                GreifeAn(ameise);
            }
        }

        /// <summary>
        /// So wie Ameisen unterschiedliche Nahrungsmittel erspähen können, entdecken Sie auch 
        /// andere Spielelemente. Entdeckt die Ameise eine Wanze, so wird diese Methode aufgerufen.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:SiehtFeind(Wanze)"
        /// </summary>
        /// <param name="wanze">Erspähte Wanze</param>
        public override void SiehtFeind(Wanze wanze)
        {
            //if (Kaste == "Verteidiger" && Ziel == null)
            //{
            //    SprüheMarkierung(1, 200);
            //    GreifeAn(wanze);
            //}
            //if (Kaste == "Verteidiger")
            //{
            //    Wanzenmanager.InstanceWanze.ReportWanze(wanze);
            //}

            if (AnzahlAmeisenDerSelbenKasteInSichtweite >= 5 && Kaste == "Verteidiger")
            {               
                GreifeAn(wanze);
            }

        }

        /// <summary>
        /// Es kann vorkommen, dass feindliche Lebewesen eine Ameise aktiv angreifen. Sollte 
        /// eine feindliche Ameise angreifen, wird diese Methode hier aufgerufen und die 
        /// Ameise kann entscheiden, wie sie darauf reagieren möchte.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:WirdAngegriffen(Ameise)"
        /// </summary>
        /// <param name="ameise">Angreifende Ameise</param>
        public override void WirdAngegriffen(Ameise ameise)
        {

            if (Kaste == "ZuckerSammler")
            {
               
                LasseNahrungFallen();
                GreifeAn(ameise);
            }
            else if (AktuelleLast == 0)
            {
               
                GreifeAn(ameise);
            }

        }

        /// <summary>
        /// Es kann vorkommen, dass feindliche Lebewesen eine Ameise aktiv angreifen. Sollte 
        /// eine Wanze angreifen, wird diese Methode hier aufgerufen und die Ameise kann 
        /// entscheiden, wie sie darauf reagieren möchte.
        /// Weitere Infos unter "http://wiki.antme.net/de/API1:WirdAngegriffen(Wanze)"
        /// </summary>
        /// <param name="wanze">Angreifende Wanze</param>
        public override void WirdAngegriffen(Wanze wanze)
        {
            if (AktuelleLast > 0 && Kaste == "ZuckerSammler")
            {
                LasseNahrungFallen();
                GreifeAn(wanze);
            }
            //else if (AktuelleLast == 0)
            //{
            //    GreifeAn(wanze);
            //}
        }

        #endregion
        
        private void GeheZuZielOptimized(Spielobjekt spielobject)
        {
            int distance = Koordinate.BestimmeEntfernung(this, spielobject);
            int angle = Koordinate.BestimmeRichtung(this, spielobject);
            GeheGeradeaus(distance);
            DreheInRichtung(angle);
            ZielOptimized = spielobject;
        }

        private void GeheZuBauOptimized()
        {
            GeheZuZielOptimized(bau);
        }

        //private void GeheZuKoordinate(int x, int y)
        //{
        //    int myX = BestimmeX(this);
        //    int myY = BestimmtY(this);

        //    int diffX = x - myX;
        //    int diffY = y - myY;

        //    int distanz = (int)Math.Sqrt((diffX * diffX) * (diffY * diffY));
        //    double radiant = Math.Atan2(diffY, diffX);
        //    int richtung = (int)((radiant / (2 * Math.PI)) * 360);

        //    DreheInRichtung(richtung);
        //    GeheGeradeaus(distanz);
        //}

        //private int BestimmeX(Spielobjekt spielobjekt)
        //{
        //    int distanz = Koordinate.BestimmeEntfernung(this, bau);
        //    int richtung = Koordinate.BestimmeRichtung(bau, this);

        //    float angle = ((float)richtung / 360) * ((float)Math.PI * 2);
        //    return (int)(Math.Cos(angle) * distanz);


        //}
        //private int BestimmtY(Spielobjekt spielobjekt)
        //{
        //    int distanz = Koordinate.BestimmeEntfernung(this, bau);
        //    int richtung = Koordinate.BestimmeRichtung(bau, this);

        //    float angle = ((float)richtung / 360) * ((float)Math.PI * 2);
        //    return (int)(Math.Sin(angle) * distanz);

        //}

        //private int BestimmeX(CoreAnt spielobjekt)
        //{
        //    int distanz = Koordinate.BestimmeEntfernung(this, bau);
        //    int richtung = Koordinate.BestimmeRichtung(bau, this);

        //    float angle = ((float)richtung / 360) * ((float)Math.PI * 2);
        //    return (int)(Math.Cos(angle) * distanz);


        //}
        //private int BestimmtY(CoreAnt spielobjekt)
        //{
        //    int distanz = Koordinate.BestimmeEntfernung(this, bau);
        //    int richtung = Koordinate.BestimmeRichtung(bau, this);

        //    float angle = ((float)richtung / 360) * ((float)Math.PI * 2);
        //    return (int)(Math.Sin(angle) * distanz);

        //}
    }

}
