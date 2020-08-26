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

    private static int assetTurn = 0;
    private static float counter = 0f;
    private static int iTo;

    private void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                counter = -1;
            }
        }
        if (counter == -1)
        {
            assetTurn += 1;
            counter = 0;
            UseCards();
        }
    }

    public void EnemyTurn()
    {
        assetTurn = 1;

        UseCards();
    }

    private void UseCards()
    {
        GetEnemyElementCards();
        Card card = new Card();
        switch (Hero.heroes[1].title)
        {
            case "Fire":
                iTo = 11;
                if (fire.Count >= Asset.assets[iTo].minCards && assetTurn == 1)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Fire")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 13;
                if (fire.Count + earth.Count >= Asset.assets[iTo].minCards && assetTurn == 2)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Fire" || Card.cards[i].element == "Earth")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 14;
                if (fire.Count + air.Count >= Asset.assets[iTo].minCards && assetTurn == 3)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Fire" || Card.cards[i].element == "Air")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 12;
                if (fire.Count + water.Count >= Asset.assets[iTo].minCards && assetTurn == 4)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Fire" || Card.cards[i].element == "Water")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                break;

            case "Water":
                iTo = 11;
                if (water.Count >= Asset.assets[iTo].minCards && assetTurn == 1)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Water")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 13;
                if (water.Count + earth.Count >= Asset.assets[iTo].minCards && assetTurn == 2)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Water" || Card.cards[i].element == "Earth")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 14;
                if (water.Count + air.Count >= Asset.assets[iTo].minCards && assetTurn == 3)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Water" || Card.cards[i].element == "Air")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 12;
                if (water.Count + fire.Count >= Asset.assets[iTo].minCards && assetTurn == 4)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Water" || Card.cards[i].element == "Fire")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                break;

            case "Earth":
                iTo = 11;
                if (earth.Count >= Asset.assets[iTo].minCards && assetTurn == 1)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Earth")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 12;
                if (earth.Count + fire.Count >= Asset.assets[iTo].minCards && assetTurn == 2)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Earth" || Card.cards[i].element == "Fire")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 14;
                if (earth.Count + air.Count >= Asset.assets[iTo].minCards && assetTurn == 3)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Earth" || Card.cards[i].element == "Air")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 13;
                if (earth.Count + water.Count >= Asset.assets[iTo].minCards && assetTurn == 4)
                {
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Earth" || Card.cards[i].element == "Water")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                break;

            case "Air":
                iTo = 11;
                if (air.Count >= Asset.assets[iTo].minCards && assetTurn == 1)
                {
                    
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Air")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 3f;
                    return;
                }

                iTo = 14;
                if (air.Count + earth.Count >= Asset.assets[iTo].minCards && assetTurn == 2)
                {
                    
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Air" || Card.cards[i].element == "Earth")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 13;
                if (air.Count + water.Count >= Asset.assets[iTo].minCards && assetTurn == 3)
                {
                    
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Air" || Card.cards[i].element == "Water")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                iTo = 12;
                if (air.Count + fire.Count >= Asset.assets[iTo].minCards && assetTurn == 4)
                {
                    
                    for (int i = 10; i < Card.SIZE; i++)
                    {
                        if (Card.occupied[i])
                        {
                            if (Card.cards[i].element == "Air" || Card.cards[i].element == "Fire")
                            {
                                card.CardClicked(i);
                                if (card.GetSelectedCards().Count == Asset.assets[iTo].maxCards)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Asset asset = new Asset();
                    asset.AssetClicked(iTo);
                    counter = 2.5f;
                    return;
                }

                break;
        }

        if (assetTurn == 5)
        {
            Hero hero = new Hero();
            hero.NewTurn();
            return;
        }
        counter = -1;
    }

    private void GetEnemyElementCards()
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
