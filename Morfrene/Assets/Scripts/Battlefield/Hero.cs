using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public const int SIZE = 2;
    public static GameObject[] Heroes = new GameObject[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Heroes[i] = GameObject.Find("Hero" + i);
        }
    }
}
