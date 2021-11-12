﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Laura_Gagliani
{
    class Menu
    {
        static DbManager db = new DbManager();

        internal static void Start()
        {
            bool quit = false;

            do
            {
                Console.WriteLine(".......... MENU ..........");
                Console.WriteLine("[1] Visualizza tutti gli agenti di polizia");
                Console.WriteLine("[2] Visualizza agenti per area scelta");
                Console.WriteLine("[3] Visualizza agenti per anni di servizio minimi");
                Console.WriteLine("[4] Inserisci nuovo agente");
                
                Console.WriteLine("[0] Esci");

                int choice = GetMenuInt(0, 4);

                switch (choice)
                {
                    case 0:
                        quit = true;
                        Console.WriteLine("Chiusura in corso...");
                        break;

                    case 1:
                        StampaTutti();
                        break;

                    case 2:
                        StampaPerArea();
                        break;

                    case 3:
                        StampaPerAnniServizioMin();
                        break;

                    case 4:
                        InserisciNuovoAgente();
                        break;

                    
                }


            } while (!quit);
        }

        private static void InserisciNuovoAgente()
        {
            Console.WriteLine("------ INSERIMENTO DATI ------");
            Console.Write("\nNome:");
            string nome = Console.ReadLine();
            Console.Write("\nCognome:");
            string cognome = Console.ReadLine();
            Console.Write("\nCodice fiscale:"); 
            string codiceFiscale = Console.ReadLine();
            Console.Write("\nArea geografica assegnata:");
            string areaGeografica = Console.ReadLine();
            Console.Write("\nAnni di servizio:");
            int anniServizio = GetInt();

            Agente nuovoAgente = new Agente(nome, cognome, codiceFiscale, areaGeografica, anniServizio);
            Agente agenteStessoCod = db.GetByCodiceFiscale(codiceFiscale);
            
            if (agenteStessoCod == null)
            {
                bool isAdded = db.Add(nuovoAgente);
                if (isAdded)
                {
                    Console.WriteLine("\nAgente inserito con successo nel database");
                }
                else
                {
                    Console.WriteLine("\nAttenzione! Inserimento non riuscito");
                }
            }
            else
            {
                Console.WriteLine("\nErrore! Nel database è già presente un agente con lo stesso codice fiscale");
                Console.WriteLine("Inserimento annullato");
            }

        }

        private static void StampaPerAnniServizioMin()
        {
            Console.WriteLine("\nInserisci anni di servizio minimi richiesti:");
            int anniMin = GetInt();
            List<Agente> agentiPerAnniMin = db.GetByAnniServizioMinimi(anniMin);
            if (agentiPerAnniMin.Count == 0)
            {
                Console.WriteLine("\nAttenzione! Nessun risultato trovato per l'input fornito");
            }
            else
            {
                Console.WriteLine($"\nGli agenti di pattuglia con anni di servizio uguali o superiori a {anniMin} sono:");
                Console.WriteLine("\n------------------------------------------------------");
                StampaLista(agentiPerAnniMin);
                Console.WriteLine("------------------------------------------------------\n");
            }
        }

        private static void StampaPerArea()
        {
            Console.WriteLine("\nInserisci area geografica desiderata:");
            string areaCercata = Console.ReadLine();
            List<Agente> agentiPerArea = db.GetByAreaGeografica(areaCercata);
            if (agentiPerArea.Count == 0)
            {
                Console.WriteLine("\nAttenzione! Nessun risultato trovato per l'input fornito");
            }
            else
            {
                Console.WriteLine($"\nGli agenti di pattuglia nell'area {areaCercata} sono:");
                Console.WriteLine("\n------------------------------------------------------");
                StampaLista(agentiPerArea);
                Console.WriteLine("------------------------------------------------------\n");
            }
        }

        private static void StampaTutti()
        {
            Console.WriteLine("\nGli agenti registrati nel database sono:");
            Console.WriteLine("\n------------------------------------------------------");
            List<Agente> agenti = db.GetAll();
            StampaLista(agenti);
            Console.WriteLine("------------------------------------------------------\n");
        }





        private static int GetMenuInt(int min, int max)
        {
            bool isInt;
            int num;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out num);

            } while (!isInt || num < min || num > max);

            return num;
        }

        private static int GetInt()
        {
            bool isInt;
            int num;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out num);

            } while (!isInt || num < 0);

            return num;
        }

        private static void StampaLista(List<Agente> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
