using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public void DealDamage(bool player, double _amount)
    {
        AnimaText animaText = new AnimaText();
        GameObject target = Hero.Heroes[0];
        if (!player)
        {
            target = Hero.Heroes[1];
        }
        int amount = (int)_amount;

        animaText.DisplayText(target, "-" + amount.ToString(), Color.red, 1.5f);
    }

    public void Heal(bool player, double _amount)
    {
        AnimaText animaText = new AnimaText();
        GameObject target = Hero.Heroes[0];
        if (!player)
        {
            target = Hero.Heroes[1];
        }
        int amount = (int)_amount;

        animaText.DisplayText(target, "+" + amount.ToString(), Color.green, 1.5f);
    }

    public void GainArmor(bool player, double _amount)
    {
        AnimaText animaText = new AnimaText();
        GameObject target = Hero.Heroes[0];
        if (!player)
        {
            target = Hero.Heroes[1];
        }
        int amount = (int)_amount;

        animaText.DisplayText(target, "Armor +" + amount.ToString(), Color.gray, 1.5f);
    }

    public void Poison(bool player, double _amount)
    {
        AnimaText animaText = new AnimaText();
        GameObject target = Hero.Heroes[0];
        if (!player)
        {
            target = Hero.Heroes[1];
        }
        int amount = (int)_amount;

        animaText.DisplayText(target, "Poison +" + amount.ToString(), Color.magenta, 1.5f);
    }

    public void UpgradeCards(bool player, double _amount)
    {
        int iStart = 0;
        if (!player)
        {
            iStart += 10;
        }
        int amount = (int)_amount;

        for (int i = iStart; i < Card.SIZE/2; i++)
        {
            if (Card.occupied[i])
            {
                Card.cards[i].value += amount;
                Card.Cards[i].GetComponentInChildren<Text>().text = "     " + Card.cards[i].element.Substring(0, 1) + "\n<size=34>" + Card.cards[i].value + "</size>\n" + Card.cards[i].element.Substring(0, 1) + "     ";
            }
        }
    }
}
