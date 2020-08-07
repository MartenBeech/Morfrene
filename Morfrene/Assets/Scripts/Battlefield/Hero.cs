using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public const int SIZE = 2;
    public static GameObject[] Heroes = new GameObject[SIZE];
    public static Hero[] heroes = new Hero[SIZE];
    public static bool playerTurn = false;
    private static float counter = 0f;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Heroes[i] = GameObject.Find("Hero" + i);
            heroes[i] = new Hero();
        }
        NewBattle("Earth");
    }

    private void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                Enemy enemy = new Enemy();
                enemy.EnemyTurn();
            }
        }
    }

    public int health = 0;
    public int maxHealth = 0;
    public string title;
    public Sprite image;
    public double fireAshDamage = 1;
    public double poisonDamage = 0;

    public void NewBattle(string element)
    {
        Asset asset = new Asset();
        heroes[1].title = element;
        switch (element)
        {
            case "Fire":
                asset.AddAsset("Fireball", false);
                asset.AddAsset("Magmattack", false);
                asset.AddAsset("Meteor", false);
                asset.AddAsset("Ash", false);
                break;

            case "Water":
                asset.AddAsset("Tidal Wave", false);
                asset.AddAsset("Magmattack", false);
                asset.AddAsset("Poison", false);
                asset.AddAsset("Monsoon", false);
                break;

            case "Earth":
                asset.AddAsset("Stoneblock", false);
                asset.AddAsset("Meteor", false);
                asset.AddAsset("Poison", false);
                asset.AddAsset("Clarity", false);
                break;

            case "Air":
                asset.AddAsset("Fast Forward", false);
                asset.AddAsset("Ash", false);
                asset.AddAsset("Monsoon", false);
                asset.AddAsset("Clarity", false);
                break;
        }
        heroes[1].image = Resources.Load<Sprite>("BattlefieldImages/" + element + "Boss");
        

        for (int i = 0; i < SIZE; i++)
        {
            heroes[i].fireAshDamage = 1;
            heroes[i].poisonDamage = 0;
            Heroes[i].GetComponentInChildren<Image>().sprite = heroes[i].image;
        }
        
        for (int i = 0; i < 15; i++)
        {
            Asset.Assets[i].GetComponentInChildren<Image>().color = Color.white;
            asset.DisplayAssetDescription(i);
        }
        NewTurn();
    }

    public void NewTurn()
    {
        if (playerTurn && heroes[0].poisonDamage > 0)
        {
            Damage damage = new Damage();
            damage.DealDamage(playerTurn, heroes[0].poisonDamage);
        }
        else if (!playerTurn && heroes[1].poisonDamage > 0)
        {
            Damage damage = new Damage();
            damage.DealDamage(playerTurn, heroes[1].poisonDamage);
        }

        playerTurn = !playerTurn;

        Deck deck = new Deck();
        if (playerTurn)
        {
            for (int i = 0; i < 11; i++)
            {
                Asset.Assets[i].GetComponentInChildren<Image>().color = Color.white;
                Asset.Assets[i].GetComponentInChildren<Button>().enabled = true;
            }
            for (int i = 11; i < 15; i++)
            {
                Asset.Assets[i].GetComponentInChildren<Button>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < 11; i++)
            {
                Asset.Assets[i].GetComponentInChildren<Button>().enabled = false;
            }
            for (int i = 11; i < 15; i++)
            {
                Asset.Assets[i].GetComponentInChildren<Image>().color = Color.white;
                Asset.Assets[i].GetComponentInChildren<Button>().enabled = true;
            }
            counter = 2;
        }
        deck.NewDeck();
        deck.DrawRandom(5, playerTurn);
    }
}
