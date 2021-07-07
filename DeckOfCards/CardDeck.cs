using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class CardDeck
    {
        string[] cardSuit = new string[] { "Clubs", "Diamond", "Heart", "Spade" };
        string[] cardRank = new string[] {"2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"};
        List<string> checkCard = new List<string>();
        
        public void DistributeCards()
        {
            string[,] cardDeck = new string[cardSuit.Length, cardRank.Length];
            string[,] checkCardDeck = new string[cardSuit.Length, cardRank.Length];

            for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardRank.Length; j++)
                {
                    cardDeck[i, j] = $"{cardRank[j]} of {cardSuit[i]}";
                }
            }
            for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardRank.Length; j++)
                {
                    Console.Write($"{cardDeck[i,j]} , ");
                }
                Console.WriteLine("\n****************");
            }

            Dictionary<string, HashSet<string>> players = new Dictionary<string, HashSet<string>>();

            Random rand = new Random();
            int randomSuit, randomRank;
            int k = 1;
            while (k <= 4)
            {
                HashSet<string> playerCard = new HashSet<string>();
                while (playerCard.Count < 9)
                {
                    randomSuit = rand.Next(0, cardSuit.Length);
                    randomRank = rand.Next(0, cardRank.Length);
                    if (!checkCard.Contains(cardDeck[randomSuit, randomRank]))
                    {
                        playerCard.Add(cardDeck[randomSuit, randomRank]);
                        checkCard.Add(cardDeck[randomSuit, randomRank]);
                    }
                }
                players.Add($"Player{k++}", playerCard);

                
            }
            Console.WriteLine($"*********{checkCard.Count}*******");

            foreach(KeyValuePair<string,HashSet<string>> i in players)
            {
                Console.WriteLine($"*********\n{i.Key} has\n***********");
                foreach(string j in i.Value)
                {
                    Console.WriteLine(j);
                }
            }

        }

    }
}
