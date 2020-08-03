using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public const int SIZE = 20;
    public static GameObject[] cards = new GameObject[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE/2; i++)
        {
            cards[i] = GameObject.Find("Card0" + i);
            cards[i + SIZE/2] = GameObject.Find("Card1" + i);
        }
    }
}
