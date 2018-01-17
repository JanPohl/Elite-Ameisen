using AntMe.Deutsch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.Warmeisen2
{
    public class Ticketmanager
    {
        #region Singleton
        private static Ticketmanager _instance;

        public static Ticketmanager Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new Ticketmanager();
                return _instance;
            }
        }
        #endregion

        //private List<Zucker> zuckers = new List<Zucker>();
        private List<Warmeisen2Klasse> ameisen = new List<Warmeisen2Klasse>();
        private Queue<Ticket> tickets = new Queue<Ticket>();



        internal void ReportSugar(Zucker zucker)
        {
            bool known = false;
            foreach (var ticket in tickets)
            {
                if (ticket.Zucker == zucker)
                {
                    known = true;
                    break;
                }
            }
            if (!known)
            {
                //zuckers.Add(zucker);
                int mengeTickets = zucker.Menge / 20;
                for (int i = 0; i < mengeTickets; i++)
                {
                    tickets.Enqueue(item: new Ticket() { Zucker = zucker });
                }
            }
        }



        internal void RegisterAmeise(Warmeisen2Klasse ameise)
        {
            if (!ameisen.Contains(ameise))
            {
                ameisen.Add(ameise);
            }

        }

        internal void UnregisterAmeise(Warmeisen2Klasse ameise, Ticket ticket)
        {
            if (ticket != null)
            {
                tickets.Enqueue(ticket);
            }

            ameisen.Remove(ameise);
        }

        internal Ticket GetTicket()
        {
            if (tickets.Count > 0)
            {
                return tickets.Dequeue();
            }
            return null;
        }


    }
    public class Ticket
    {
        public Zucker Zucker { get; set; }

    }

}
