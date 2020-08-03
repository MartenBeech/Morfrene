using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public const int SIZE = 2;
    public static GameObject[] decks = new GameObject[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            decks[i] = GameObject.Find("Deck" + i);
        }
    }
}
