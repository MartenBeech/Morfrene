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
    public static bool[] selected = new bool[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE/2; i++)
        {
            Cards[i] = GameObject.Find("Card0" + i);
            Cards[i + SIZE/2] = GameObject.Find("Card1" + i);
        }

        for (int i = 0; i < SIZE; i++)
        {
            Cards[i].GetComponentInChildren<Image>().enabled = false;
        }
    }

    public int value = 0;
    public string element = "";
    public Sprite image;

    public void AddCard(Card card, int space)
    {
        cards[space] = new Card();
        cards[space].value = card.value;
        cards[space].element = card.element;
        cards[space].image = card.image;
        occupied[space] = true;
    }

    public void RemoveCard(int space)
    {
        if (occupied[space])
        {
            if (selected[space])
            {
                CardClicked(space);
            }
            cards[space] = null;
            occupied[space] = false;
            Cards[space].GetComponentInChildren<Text>().text = null;
            Cards[space].GetComponentInChildren<Image>().color = Color.white;
            Cards[space].GetComponentInChildren<Image>().enabled = false;
        }
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

    public void CardClicked(int i)
    {
        if (occupied[i])
        {
            if (!selected[i])
            {
                selected[i] = true;
                Cards[i].GetComponentInChildren<Transform>().position = new Vector3(
                    Cards[i].GetComponentInChildren<Transform>().position.x,
                    Cards[i].GetComponentInChildren<Transform>().position.y + 0.25f,
                    Cards[i].GetComponentInChildren<Transform>().position.z);
            }
            else
            {
                selected[i] = false;
                Cards[i].GetComponentInChildren<Transform>().position = new Vector3(
                    Cards[i].GetComponentInChildren<Transform>().position.x,
                    Cards[i].GetComponentInChildren<Transform>().position.y - 0.25f,
                    Cards[i].GetComponentInChildren<Transform>().position.z);
            }
        }
    }

    public List<int> GetSelectedCards()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < SIZE; i++)
        {
            if (selected[i])
                list.Add(i);
        }
        return list;
    }
}
