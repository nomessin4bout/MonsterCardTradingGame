﻿namespace MCTG.Server
{
    internal class Stack
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        public void AddCard(Card card)
        {
           Cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
        }
    }
}
