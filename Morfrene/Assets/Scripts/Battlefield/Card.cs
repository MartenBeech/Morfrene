using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public const int SIZE = 20;
    public static GameObject[] Cards = new GameObject[SIZE];
    public static Card[] cards = new Card[SIZE];
    public static bool[] occupied = new bool[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE/2; i++)
        {
            Cards[i] = GameObject.Find("Card0" + i);
            Cards[i + SIZE/2] = GameObject.Find("Card1" + i);
        }
    }

    public string title = "";
    //FF - Fireball
    //II
    //EE - Stoneskin
    //WW
    //FI
    //FE - Meteor
    //FW
    //IE - Mudblast
    //IW - Watergun
    //EW
    public int value = 0;
    public string shape = "";
    public Sprite image;

    public void AddCard(Card card, int space)
    {
        cards[space] = new Card();
        cards[space].value = card.value;
        cards[space].shape = card.shape;
        cards[space].image = card.image;
        occupied[space] = true;
    }

    public void RemoveCard(int space)
    {
        cards[space] = null;
        occupied[space] = false;
    }

    public void RemoveAllCards()
    {
        for (int i = 0; i < SIZE; i++)
        {
            RemoveCard(i);
        }
    }

    public int GetAvailableSpace(bool player)
    {
        int lowRange;
        int highRange;
        if (player)
        {
            lowRange = 0;
            highRange = SIZE / 2;
        }
        else
        {
            lowRange = SIZE / 2;
            highRange = SIZE;
        }

        for (int i = lowRange; i < highRange; i++)
        {
            if (!occupied[i])
                return i;
        }
        return SIZE;
    }
}
