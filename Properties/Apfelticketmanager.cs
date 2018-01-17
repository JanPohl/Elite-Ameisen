using AntMe.Deutsch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.Warmeisen2
{
       public class Apfelticketmanager
    {
        
        #region Singleton
        private static Apfelticketmanager _instanceapfel;

        public static Apfelticketmanager InstanceApfel
        {
            get
            {
                if (_instanceapfel == null)

                    _instanceapfel = new Apfelticketmanager();
                return _instanceapfel;
            }
        }
        #endregion

        //private List<Obst> obstler = new List<Obst>();
        private List<Warmeisen2Klasse> apfelameisen = new List<Warmeisen2Klasse>();
        private Queue<ApfelTicket> ticketsapfel = new Queue<ApfelTicket>();



        internal void ReportFruit(Obst obst)
        {
            bool known = false;
            foreach (var apfelticket in ticketsapfel)
            {
                if (apfelticket.Obst == obst)
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
                int mengeApfelTickets = 4;
                for (int i = 0; i < mengeApfelTickets; i++)
                {
                    ticketsapfel.Enqueue(new ApfelTicket() { Obst = obst });
                }
            }
        }

       
        internal void RegisterApfelAmeise(Warmeisen2Klasse apfelameise)
        {
            if (!apfelameisen.Contains(apfelameise))
            {
                apfelameisen.Add(apfelameise);
            }

        }

        internal void UnregisterApfelAmeise(Warmeisen2Klasse apfelameise)
        {
                       apfelameisen.Remove(apfelameise);
        }



        internal ApfelTicket GetApfelTicket()
        {
            if (ticketsapfel.Count > 0)
            {
                return ticketsapfel.Dequeue();
            }
            return null;
        }
    }



    public class ApfelTicket
    {

        public Obst Obst { get; set; }
    }
}
