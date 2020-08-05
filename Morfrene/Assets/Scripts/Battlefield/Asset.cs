using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asset : MonoBehaviour
{
    public const int SIZE = 10;
    public static GameObject[] Assets = new GameObject[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE/2; i++)
        {
            Assets[i] = GameObject.Find("Asset0" + i);
            Assets[i + SIZE / 2] = GameObject.Find("Asset1" + i);
        }
    }
}
