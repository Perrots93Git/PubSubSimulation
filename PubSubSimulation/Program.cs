using System;
using System.Collections.Generic;

namespace PubSubSimulation
{
    class Program
    {

        public void PublishingMessage(List<string> messages , Exchange exchange)
        {
            exchange.SendMessage(messages);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Exchange exchange = new Exchange();

            List<string> publishingMessages = new List<string>();
            List<string> subscriberMessagesA = new List<string>();
            List<string> subscriberMessagesB = new List<string>();

            //sottoscrivo le due code all'exchange
            exchange.Subscribe(subscriberMessagesA);
            exchange.Subscribe(subscriberMessagesB);

            //aggiungo messaggi alla lista di messaggi
            for (int i = 0; i < 5; i++)
            {
                publishingMessages.Add(string.Concat("Messaggio ", i.ToString())); 
            }
            
            //pubblico i messaggi
            program.PublishingMessage(publishingMessages, exchange);


            //stampo a console la lista originale
            Console.WriteLine("LISTA MESSAGGI ORIGINALE:");
            Console.WriteLine("-----------");

            foreach (string s in publishingMessages)
            {
                Console.WriteLine(s);

            }

            Console.WriteLine("-----------");

            //stampo a console la coda A ---> mi aspetto di ottenere tutti i messaggi della lista originale
            Console.WriteLine("CODA A:");
            Console.WriteLine("-----------");

            foreach (string s in subscriberMessagesA)
            {
                Console.WriteLine(s);

            }

            Console.WriteLine("-----------");

            //stampo a console la coda B ---> mi aspetto di ottenere tutti i messaggi della lista originale
            Console.WriteLine("CODA B:");
            Console.WriteLine("");

            foreach (string s in subscriberMessagesB)
            {
                Console.WriteLine(s);

            }

            Console.WriteLine("-----------");
        }

    }

    class Exchange
    {
        public List<List<string>> Subscribers { get; set; }

        public Exchange()
        {
            Subscribers = new List<List<string>>();
        }

        public void Subscribe(List<string> service)
        {
            Subscribers.Add(service);

        }

        public void UnSubscribe(List<string> service)
        {
            Subscribers.Remove(service);

        }

        public void SendMessage(List<string> messages)
        {
            foreach (string message in messages)
            {
                foreach (List<string> s in Subscribers)
                {
                    s.Add(message);
                }
            }

        }


    }

}
