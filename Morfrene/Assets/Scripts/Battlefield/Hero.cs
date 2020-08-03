using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public const int SIZE = 2;
    public static GameObject[] heroes = new GameObject[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            heroes[i] = GameObject.Find("Hero" + i);
        }
    }
}
