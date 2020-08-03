using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaCard : MonoBehaviour
{
    public static GameObject startSet;
    public static GameObject endSet;
    public static int iTo;
    public static GameObject prefab;
    public static GameObject parent;
    public static Card card;
    private GameObject startPoint;
    private GameObject endPoint;
    private int _to;

    private static float counterSet;
    private float counterStart;
    private float counter;




    private void Awake()
    {
        startPoint = startSet;
        endPoint = endSet;
        _to = iTo;
        counter = counterSet;
        counterStart = counterSet;
    }

    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPoint.transform.position - startPoint.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPoint.transform.position.x - startPoint.transform.position.x, 2) +
                Mathf.Pow(endPoint.transform.position.y - startPoint.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * Time.deltaTime / counterStart);
        }

        else if (counter <= 0)
        {
            Card.Cards[_to].GetComponentInChildren<Text>().text = Card.cards[_to].shape + " " + Card.cards[_to].value;
            Card.Cards[_to].GetComponentInChildren<Image>().sprite = Card.cards[_to].image;
            Destroy(gameObject);
        }

        counter -= Time.deltaTime;
    }

    public void MoveDeckCard(Card _card, int to)
    {
        prefab = Resources.Load<GameObject>("Prefabs/Card");
        parent = GameObject.Find("Animation");
        card = _card;
        iTo = to;
        startSet = Deck.Decks;
        endSet = Card.Cards[to];

        float pos = to;
        if (pos >= 10)
        {
            pos -= 10;
        }
        counterSet = 1 + (pos / 10);

        prefab.GetComponentInChildren<Image>().sprite = Deck.Decks.GetComponentInChildren<Image>().sprite;
        prefab = Instantiate(prefab, startSet.transform.position, startSet.transform.rotation, parent.transform);
    }
}
