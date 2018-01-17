using AntMe.Deutsch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.Warmeisen2
{
    public class Wanzenmanager
    {



        #region Singleton
        private static Wanzenmanager _instancewanze;

        public static Wanzenmanager InstanceWanze
        {
            get
            {
                if (_instancewanze == null)

                    _instancewanze = new Wanzenmanager();
                return _instancewanze;
            }
        }
        #endregion

        //private List<Obst> obstler = new List<Obst>();
        private List<Warmeisen2Klasse> verteidigerameisen = new List<Warmeisen2Klasse>();
        private Queue<WanzenTicket> ticketswanze = new Queue<WanzenTicket>();



        internal void ReportWanze(Wanze wanze)
        {
            bool known = false;
            foreach (var wanzenticket in ticketswanze)
            {
                if (wanzenticket.Wanze == wanze)
                {
                    known = true;
                    break;
                }
            }
            if (!known)
            {
                //   if (!obstler.Contains(obst))
                // {
                //    obstler.Add(obst);
                int mengeWanzenTickets = 6;
                for (int i = 0; i < mengeWanzenTickets; i++)
                {
                    ticketswanze.Enqueue(new WanzenTicket() { Wanze = wanze });
                }
            }
        }


        internal void RegisterVerteidigerAmeise(Warmeisen2Klasse verteidigerameise)
        {
            if (!verteidigerameisen.Contains(verteidigerameise))
            {
                verteidigerameisen.Add(verteidigerameise);
            }

        }

        internal void UnregisterVerteidigerAmeise(Warmeisen2Klasse verteidigerameise)
        {
            verteidigerameisen.Remove(verteidigerameise);
        }



        internal WanzenTicket GetWanzenTicket()
        {
            if (ticketswanze.Count > 0)
            {
                return ticketswanze.Dequeue();
            }
            return null;
        }




    }

    public class WanzenTicket
    {

        public Wanze Wanze { get; set; }
    }
}

