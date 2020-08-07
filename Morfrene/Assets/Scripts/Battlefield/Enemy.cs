using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    List<Card> fire = new List<Card>();
    List<Card> water = new List<Card>();
    List<Card> earth = new List<Card>();
    List<Card> air = new List<Card>();

    private static float counter = 0f;
    private static int iTo;

    private void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                Asset asset = new Asset();
                asset.ActivateAsset(iTo, false);
            }
        }
    }

    public void EnemyTurn()
    {
        int cardsSelected = 0;
        switch (Hero.heroes[1].title)
        {
            case "Fire":
                if (fire.Count >= 4)
                {

                }
                break;
        }
    }

    private void SetEnemyElementCards()
    {
        fire.Clear();
        water.Clear();
        earth.Clear();
        air.Clear();

        for (int i = 10; i < Card.SIZE; i++)
        {
            if (Card.occupied[i])
            {
                if (Card.cards[i].element == "Fire")
                    fire.Add(Card.cards[i]);
                else if (Card.cards[i].element == "Water")
                    water.Add(Card.cards[i]);
                else if (Card.cards[i].element == "Earth")
                    earth.Add(Card.cards[i]);
                else if (Card.cards[i].element == "Air")
                    air.Add(Card.cards[i]);
            }
        }
    }
}
