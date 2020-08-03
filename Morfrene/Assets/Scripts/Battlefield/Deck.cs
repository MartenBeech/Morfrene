using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public static GameObject Decks;
    public static int cardsSize = 52;
    public static Card[] cards = new Card[cardsSize];

    private void Start()
    {
        Decks = GameObject.Find("Deck");

        NewDeck();
    }

    public void DrawRandom(int amount, bool player)
    {
        Card card = new Card();
        int rnd;
        int space;

        for (int i = 0; i < amount; i++)
        {
            rnd = Random.Range(0, cardsSize);
            card = cards[rnd];
            space = card.GetAvailableSpace(player);
            if (space < Card.SIZE)
            {
                card.AddCard(card, space);
                AnimaCard animaCard = new AnimaCard();
                animaCard.MoveDeckCard(card, space);
                cardsSize--;
                cards[rnd].value = cards[cardsSize].value;
                cards[rnd].shape = cards[cardsSize].shape;
                cards[rnd].image = cards[cardsSize].image;
                cards[cardsSize] = null;
            }
        }
    }

    public void NewDeck()
    {
        cardsSize = 52;
        Card card = new Card();
        card.RemoveAllCards();
        for (int i = 0; i < cardsSize; i++)
        {
            cards[i] = new Card();
            cards[i].value = (i % 13) + 1;
            if (i < 13)
            {
                cards[i].shape = "Chrono";
            }
            else if (i < 26)
            {
                cards[i].shape = "Velocity";
            }
            else if (i < 39)
            {
                cards[i].shape = "Force";
            }
            else if (i < 52)
            {
                cards[i].shape = "Energy";
            }
        }
    }

    public void DeckClicked()
    {
        //NewDeck();
        DrawRandom(10, true);
        DrawRandom(10, false);
    }
}
