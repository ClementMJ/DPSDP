﻿using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------------------------");



            Console.WriteLine("Exercice 1");
            Exo1();
            Console.WriteLine("Exercice 2");
            Exo2();
            Console.WriteLine("Exercice 3");
            Exo3();
            Console.ReadKey();
        }
        static void Exo1()
        {
            Node<int> node1 = new Node<int>(1);
            CustomQueue<int> customQueue = new CustomQueue<int>(node1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Console.WriteLine("Dequeue : " + customQueue.Dequeue().data);
            customQueue.Enqueue(1);
            Console.WriteLine("For each loop:");
            foreach (Node<int> node in customQueue)
            {
                Console.WriteLine(node.data);
            }
        }

        static void Exo2()
        {
            Console.WriteLine("Welcome to Monopoly Game !");
            Console.WriteLine("Choose how many players do you want for this game :");
            int nbPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now, choose how many rounds do you want for this game :");
            int nbRounds = Convert.ToInt32(Console.ReadLine());
            CollectionPlayer listPlayers = new CollectionPlayer();
            for (int i = 0; i < nbPlayers; i++)
            {

                //listPlayers.Players;

            }
            int size = 40;
            Game game = new Game(size, nbPlayers, nbRounds);

            game.PlayGame();

            Iterator iterator = listPlayers.CreateIterator();
            //listPlayers.Next;
        }
        static void Exo3()
        {

        }
    }
}
