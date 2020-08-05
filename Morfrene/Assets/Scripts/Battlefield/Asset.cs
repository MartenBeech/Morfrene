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
        for (int i = 11; i < 15; i++)
        {
            Assets[i] = GameObject.Find("Asset1" + (i - 11));
            TextLevels[i] = GameObject.Find("TextLevel1" + (i - 11));
            TextNames[i] = GameObject.Find("TextName1" + (i - 11));
            TextElements[i] = GameObject.Find("TextElement1" + (i - 11));
        }
    }

    public string title = "";
    public string element = "";
    public int level = 0;
    public int power = 0;
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
                        assets[i].power = 30;
                        break;

                    case "Tidal Wave":
                        assets[i].element = "Water";
                        assets[i].power = 3;
                        break;

                    case "Stoneblock":
                        assets[i].element = "Earth";
                        assets[i].power = 30;
                        break;

                    case "Rewind":
                        assets[i].element = "Air";
                        assets[i].power = 5;
                        break;

                    case "Magmattack":
                        assets[i].element = "FireWater";
                        assets[i].power = 2;
                        break;

                    case "Meteor":
                        assets[i].element = "FireEarth";
                        assets[i].power = 1;
                        break;

                    case "Fire Ash":
                        assets[i].element = "FireAir";
                        assets[i].power = 1;
                        break;

                    case "Poison":
                        assets[i].element = "WaterEarth";
                        assets[i].power = 5;
                        break;

                    case "Monsoon":
                        assets[i].element = "WaterAir";
                        assets[i].power = 1;
                        break;

                    case "Clarity":
                        assets[i].element = "EarthAir";
                        assets[i].power = 3;
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
                assets[i].power += 15;
                break;

            case "Tidal Wave":
                assets[i].power += 1;
                break;

            case "Stoneblock":
                assets[i].power += 15;
                break;

            case "Rewind":
                assets[i].power += 3;
                break;

            case "Magmattack":
                assets[i].power += 2;
                break;

            case "Meteor":
                assets[i].power += 1;
                break;

            case "Fire Ash":
                assets[i].power += 1;
                break;

            case "Poison":
                assets[i].power += 3;
                break;

            case "Monsoon":
                assets[i].power += 7;
                break;

            case "Clarity":
                assets[i].power += 1;
                break;
        }
        DisplayAssetDescription(i);
    }

    private void DisplayAssetDescription(int i)
    {
        TextLevels[i].GetComponentInChildren<Text>().text = "Lvl:\n" + assets[i].level;
        TextNames[i].GetComponentInChildren<Text>().text = assets[i].title;
        TextElements[i].GetComponentInChildren<Text>().text = "Elements:\n";
        if (assets[i].element.Contains("FireWaterEarthAir"))
            TextElements[i].GetComponentInChildren<Text>().text += "All";
        else
        {
            if (assets[i].element.Contains("Fire"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=red>Fire</color> ";
            if (assets[i].element.Contains("Water"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=blue>Water</color> ";
            if (assets[i].element.Contains("Earth"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=green>Earth</color> ";
            if (assets[i].element.Contains("Air"))
                TextElements[i].GetComponentInChildren<Text>().text += "<color=gray>Air</color> ";
        }
        switch (assets[i].title)
        {
            case "Elemental Sword":
                //Assets[i].GetComponentInChildren<Text>().text = "Use up to " + assets[i].power + " cards.\nDeal X damage.\n(X = the cards' combined value)";
                break;

            case "Fireball":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 Fire cards.\nDeal " + assets[i].power + " damage";
                break;

            case "Tidal Wave":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 Water cards.\nYour cards' value increase by a factor of " + assets[i].power;
                break;

            case "Stoneblock":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 Earth cards.\nGain " + assets[i].power + " Armor";
                break;

            case "Rewind":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 Air cards.\nGain a new turn and regain " + assets[i].power + " health";
                break;

            case "Magmattack":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nDeal " + assets[i].power + " times X damage";
                break;

            case "Meteor":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nDeal X damage. Your opponent draws " + assets[i].power + " less card[s] next turn";
                break;

            case "Fire Ash":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nDeal X damage. Your opponent's cards have their value reduced by " + assets[i].power + " next turn";
                break;

            case "Poison":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nYour opponent takes damage each turn equal to X/2 + " + assets[i].power;
                break;

            case "Monsoon":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nDeal " + assets[i].power + " damage. Your future Monsoons deals X more damage";
                break;

            case "Clarity":
                //Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nDraw " + assets[i].power + " new cards";
                break;
        }

        Assets[i].GetComponentInChildren<Text>().text = "Use 3 cards.\nDeal " + assets[i].power + " damage.";
    }
}
