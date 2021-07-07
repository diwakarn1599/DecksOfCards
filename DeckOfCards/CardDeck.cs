using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    /// <summary>
    /// Extension class to find index of the element in the array
    /// </summary>
    public static class Extensions
    {
        public static int findIndex<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item);
        }
    }
    class CardDeck
    {
        
        /// <summary>
        /// Initializing suit array and rank array
        /// </summary>
        string[] cardSuit = new string[] { "Clubs", "Diamond", "Heart", "Spade" };
        string[] cardRank = new string[] {"2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"};
        
        
       
        List<string> checkCard = new List<string>();
        public void DistributeCards()
        {
            
           string[,] cardDeck = new string[cardSuit.Length, cardRank.Length];

           for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardRank.Length; j++)
                {
                    cardDeck[i, j] = $"{cardRank[j]} {cardSuit[i]}";
                }
            }
            PrintDeck(cardDeck);

            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();

            Random rand = new Random();
            int randomSuit, randomRank;
            int k = 1;
            while (k <= 4)
            {
                List<string> playerCard = new List<string>();
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
                players.Add($"Player {k++}", playerCard);

                
            }
            Console.WriteLine($"*********{checkCard.Count}*******");
            PrintPlayerCards(players);
        }

        /// <summary>
        /// Method for printing card hold by each players
        /// </summary>
        /// <param name="players"></param>
        public void PrintPlayerCards(Dictionary<string, List<string>> players)
        {
            foreach (KeyValuePair<string, List<string>> i in players)
            {
                //Console.WriteLine("************BEFORE SORTING**************");
                Console.WriteLine($"*********\n{i.Key} has\n***********");
                SortByRank(i.Value,i.Key);
                
            }
        }
        /// <summary>
        /// Method for printing card deck
        /// </summary>
        /// <param name="cardDeck"></param>
        public void PrintDeck(string[,] cardDeck)
        {
            for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardRank.Length; j++)
                {
                    Console.Write($"{cardDeck[i, j]} , ");
                }
                Console.WriteLine("\n****************");
            }
        }

        /// <summary>
        /// Method used to sort elements in array by rank
        /// </summary>
        /// <param name="playerCard"></param>
        /// <param name="playerName"></param>
        public void SortByRank(List<string> playerCard,string playerName)
        {
            foreach (string j in playerCard)
            {
                Console.WriteLine(j);
            }
            //Bubble sort algorithm used to sort the elements in the array
            for (int i= 0; i < playerCard.Count-1; i++)
            {
                int x,y;
                for(int j=0;j< playerCard.Count-i-1; j++)
                {
                    x = cardRank.findIndex(playerCard[j].Split(" ")[0]);
                    y = cardRank.findIndex(playerCard[j+1].Split(" ")[0]);
                    //swap if x greater than y
                    if (x > y)
                    { 
                        string temp = playerCard[j];
                        playerCard[j] = playerCard[j+1];
                        playerCard[j+1] = temp;
                    }

                }

            }
            Console.WriteLine("*****AFTER SORTING*******");
            foreach (string j in playerCard)
            {
                Console.WriteLine(j);
            }


        }


    }
}
