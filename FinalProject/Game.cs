﻿using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class Game
    {
        private List<Player> playerList;
        private CircularList<int> board;
        private Die[] dice;
        private int nbRounds = 30;
        private int size = 40;

        public Game(List<Player> playerList)
        {
            this.playerList = playerList;
            SetBoard();
        }

        public void SetBoard()
        {
            this.board = new CircularList<int>();

            for (int i = 0; i < this.size; i++)
            {
                Node<int> index = new Node<int>(i);
                this.board.AddNode(index);
            }
        }

        public void AddPlayers(Player player)
        {
            this.playerList.Add(player);
        }

        public void PlayGame()
        {
            for (int i =0; i< nbRounds; i++)
            {
                PlayRound();
            }
        }

        public void PlayRound()
        {
            foreach (Player player in this.playerList)
            {
                int temp = player.Index;
                player.Play();
                Console.WriteLine("Player: " + player.Name + " move from :" + temp +
                    "   to " + player.Index + " and his state is : " + player.Test);
                
            }
        }

    }
}
