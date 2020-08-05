using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asset : MonoBehaviour
{
    public const int SIZE = 15;
    public static GameObject[] Assets = new GameObject[SIZE];
    public static GameObject[] TextLevels = new GameObject[SIZE];
    public static GameObject[] TextNames = new GameObject[SIZE];
    public static GameObject[] TextElements = new GameObject[SIZE];
    public static Asset[] assets = new Asset[SIZE];
    public static bool[] occupied = new bool[SIZE];

    private void Start()
    {
        Assets[0] = GameObject.Find("Asset0");
        TextLevels[0] = GameObject.Find("TextLevel0");
        TextNames[0] = GameObject.Find("TextName0");
        TextElements[0] = GameObject.Find("TextElement0");
        for (int i = 1; i < 11; i++)
        {
            Assets[i] = GameObject.Find("Asset0" + (i - 1));
            TextLevels[i] = GameObject.Find("TextLevel0" + (i - 1));
            TextNames[i] = GameObject.Find("TextName0" + (i - 1));
            TextElements[i] = GameObject.Find("TextElement0" + (i - 1));
        }
        for (int i = 11; i < SIZE; i++)
        {
            Assets[i] = GameObject.Find("Asset1" + (i - 11));
            TextLevels[i] = GameObject.Find("TextLevel1" + (i - 11));
            TextNames[i] = GameObject.Find("TextName1" + (i - 11));
            TextElements[i] = GameObject.Find("TextElement1" + (i - 11));
        }

        for (int i = 0; i < SIZE; i++)
        {
            Assets[i].GetComponentInChildren<Image>().enabled = false;
            TextLevels[i].GetComponentInChildren<Text>().enabled = false;
            TextNames[i].GetComponentInChildren<Text>().enabled = false;
            TextElements[i].GetComponentInChildren<Text>().enabled = false;
        }
    }

    public string title = "";
    public string element = "";
    public int level = 0;
    public double power = 0;
    public int minCards = 0;
    public int maxCards = 0;

    public void AssetClicked(int i)
    {
        List<int> selectedCards = new List<int>();
        Card card = new Card();
        selectedCards = card.GetSelectedCards();

        for (int j = 0; j < selectedCards.Count; j++)
        {
            if (!assets[i].element.Contains(Card.cards[selectedCards[j]].element))
            {
                return;
            }
        }

        AnimaAsset animaAsset = new AnimaAsset();
        for (int j = 0; j < selectedCards.Count; j++)
        {
            animaAsset.MoveCardAsset(selectedCards[j], i);
        }
    }

    public void AddAsset(string title)
    {
        for (int i = 0; i < 11; i++)
        {
            if (occupied[i])
            {
                if (assets[i].title == title)
                {
                    UpgradeAsset(i);
                    return;
                }
            }
            else
            {
                assets[i] = new Asset();
                occupied[i] = true;
                Assets[i].GetComponentInChildren<Image>().enabled = true;
                TextLevels[i].GetComponentInChildren<Text>().enabled = true;
                TextNames[i].GetComponentInChildren<Text>().enabled = true;
                TextElements[i].GetComponentInChildren<Text>().enabled = true;
                assets[i].title = title;
                assets[i].level = 1;
                switch (title)
                {
                    case "Elemental Sword":
                        assets[i].element = "FireWaterEarthAir";
                        assets[i].power = 2;
                        break;

                    case "Fireball":
                        assets[i].element = "Fire";
                        assets[i].power = 4;
                        break;

                    case "Tidal Wave":
                        assets[i].element = "Water";
                        assets[i].power = 4;
                        break;

                    case "Stoneblock":
                        assets[i].element = "Earth";
                        assets[i].power = 4;
                        break;

                    case "Fast Forward":
                        assets[i].element = "Air";
                        assets[i].power = 5;
                        break;

                    case "Magmattack":
                        assets[i].element = "FireWater";
                        assets[i].power = 2;
                        break;

                    case "Meteor":
                        assets[i].element = "FireEarth";
                        assets[i].power = 2;
                        break;

                    case "Fire Ash":
                        assets[i].element = "FireAir";
                        assets[i].power = 1;
                        break;

                    case "Poison":
                        assets[i].element = "WaterEarth";
                        assets[i].power = 0.4;
                        break;

                    case "Monsoon":
                        assets[i].element = "WaterAir";
                        assets[i].power = 1;
                        break;

                    case "Clarity":
                        assets[i].element = "EarthAir";
                        assets[i].power = 0.5;
                        break;
                }
                DisplayAssetDescription(i);
                return;
            }
        }
    }

    private void UpgradeAsset(int i)
    {
        assets[i].level++;
        switch (assets[i].title)
        {
            case "Elemental Sword":
                assets[i].power += 1;
                break;

            case "Fireball":
                assets[i].power += 1;
                break;

            case "Tidal Wave":
                assets[i].power += 1;
                break;

            case "Stoneblock":
                assets[i].power += 1;
                break;

            case "Fast Forward":
                assets[i].power += 1;
                break;

            case "Magmattack":
                assets[i].power += 0.5;
                break;

            case "Meteor":
                assets[i].power += 0.5;
                break;

            case "Fire Ash":
                assets[i].power += 0.2;
                break;

            case "Poison":
                assets[i].power += 0.1;
                break;

            case "Monsoon":
                assets[i].power += 0.25;
                break;

            case "Clarity":
                assets[i].power += 0.25;
                break;
        }
        DisplayAssetDescription(i);
    }

    private void DisplayAssetDescription(int i)
    {
        TextLevels[i].GetComponentInChildren<Text>().text = "Lvl:\n" + assets[i].level;
        TextNames[i].GetComponentInChildren<Text>().text = assets[i].title;
        TextElements[i].GetComponentInChildren<Text>().text = "";
        if (assets[i].element.Contains("FireWaterEarthAir"))
            TextElements[i].GetComponentInChildren<Text>().text += "All  ";
        else
        {
            if (assets[i].element.Contains("Fire"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=red>Fire</color>  ";
            if (assets[i].element.Contains("Water"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=blue>Water</color>  ";
            if (assets[i].element.Contains("Earth"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=green>Earth</color>  ";
            if (assets[i].element.Contains("Air"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=gray>Air</color>  ";
        }
        switch (assets[i].title)
        {
            case "Elemental Sword":
                Assets[i].GetComponentInChildren<Text>().text = "Use up to " + assets[i].power + " cards.\nDeal X damage.\n(X = combined card value)";
                break;

            case "Fireball":
                Assets[i].GetComponentInChildren<Text>().text = "Use 4 cards.\nDeal " + assets[i].power + "X damage";
                break;

            case "Tidal Wave":
                Assets[i].GetComponentInChildren<Text>().text = "Use 4 cards.\nHeal for " + assets[i].power + "X";
                break;

            case "Stoneblock":
                Assets[i].GetComponentInChildren<Text>().text = "Use 4 cards.\nGain " + assets[i].power + "X Armor";
                break;

            case "Fast Forward":
                Assets[i].GetComponentInChildren<Text>().text = "Use 4 cards.\nDraw " + assets[i].power + " new cards";
                break;

            case "Magmattack":
                Assets[i].GetComponentInChildren<Text>().text = "Use 1 card.\nDeal " + assets[i].power + "X damage";
                break;

            case "Meteor":
                Assets[i].GetComponentInChildren<Text>().text = "Use at least 4 cards.\nDeal " + assets[i].power + "X damage";
                break;

            case "Fire Ash":
                Assets[i].GetComponentInChildren<Text>().text = "Use up to 2 cards.\nDeal 1 damage.\nYour future Fire Ashes deal " + assets[i].power + "X more damage";
                break;

            case "Poison":
                Assets[i].GetComponentInChildren<Text>().text = "Use up to 2 cards.\nDeal damage each turn equal to " + assets[i].power + "X";
                break;

            case "Monsoon":
                Assets[i].GetComponentInChildren<Text>().text = "Use up to 2 cards.\nSteal " + assets[i].power + "X health";
                break;

            case "Clarity":
                Assets[i].GetComponentInChildren<Text>().text = "Use at least 3 cards.\nYour other cards' value increase by " + assets[i].power + "X";
                break;
        }
    }
}
