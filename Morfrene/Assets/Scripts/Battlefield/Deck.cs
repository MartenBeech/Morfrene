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
                cards[rnd].element = cards[cardsSize].element;
                cards[rnd].image = cards[cardsSize].image;
                cards[cardsSize] = null;
            }
        }
    }

    public void NewDeck()
    {
        cardsSize = 40;
        Card card = new Card();
        card.RemoveAllCards();
        for (int i = 0; i < cardsSize; i++)
        {
            cards[i] = new Card();
            cards[i].value = (i % 10) + 1;

            if (i < 10)
            {
                cards[i].element = "Fire";
            }
            else if (i < 20)
            {
                cards[i].element = "Water";
            }
            else if (i < 30)
            {
                cards[i].element = "Earth";
            }
            else if (i < 40)
            {
                cards[i].element = "Air";
            }
        }
    }

    public void DeckClicked()
    {
        NewDeck();
        DrawRandom(10, true);
        //DrawRandom(1, false);
        Asset asset = new Asset();
        asset.AddAsset("Elemental Sword", true);
        asset.AddAsset("Fireball", true);
        asset.AddAsset("Tidal Wave", true);
        asset.AddAsset("Stoneblock", true);
        asset.AddAsset("Fast Forward", true);
        asset.AddAsset("Magmattack", true);
        asset.AddAsset("Meteor", true);
        asset.AddAsset("Ash", true);
        asset.AddAsset("Poison", true);
        asset.AddAsset("Monsoon", true);
        asset.AddAsset("Clarity", true);
    }
}
