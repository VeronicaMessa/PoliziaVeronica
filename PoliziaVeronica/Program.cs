using System;
using System.Collections.Generic;

namespace PoliziaVeronica
{
    class Program
    {
        static void Main(string[] args)
        {
            // mostra tutti gli agenti 
            List<Agente> _agenti = Polizia.MostraAgenti();
            foreach (Agente a in _agenti)
                Console.WriteLine(a);

            // mostra gli agenti assegnati ad una determinata area 
            int id;
            do
                Console.Write("Inserisci idArea: ");
            while (!int.TryParse(Console.ReadLine(), out id));
            List<Agente> _area = Polizia.MostraAgenti();
            Console.WriteLine($"Gli agenti che operano nell'area {id} anni sono: ");
            foreach (Agente a in _area)
                
                Console.WriteLine(a);


            //mostra agenti con anni di serivizio >= al numero inserito dall'utente 
            int anniServizio;
            do
                Console.Write("Inserisci anni: ");
            while (!int.TryParse(Console.ReadLine(), out anniServizio));
            List<Agente> anni = Polizia.AnniServizioPerAgente(anniServizio);
             Console.WriteLine($"Gli agenti che hanno più di {anniServizio} anni sono: ");
            foreach (Agente a in anni) 
                Console.WriteLine(a);


            // inserire nuovo agente (modalità disconnessa)
            Polizia.InserimentoAgente("gino", "pippo", "nekfoe", new DateTime(1990, 5, 2),6);
        }
    }
}
