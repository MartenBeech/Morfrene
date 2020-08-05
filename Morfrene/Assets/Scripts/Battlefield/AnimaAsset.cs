using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaAsset : MonoBehaviour
{
    public static GameObject startSet;
    public static GameObject endSet;
    public static GameObject prefab;
    public static GameObject parent;
    public static Card card;
    private GameObject startPoint;
    private GameObject endPoint;

    private float counter = 1f;

    private void Awake()
    {
        startPoint = startSet;
        endPoint = endSet;
    }

    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPoint.transform.position - startPoint.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPoint.transform.position.x - startPoint.transform.position.x, 2) +
                Mathf.Pow(endPoint.transform.position.y - startPoint.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * Time.deltaTime);
        }

        else if (counter <= 0)
        {
            Destroy(gameObject);
        }

        counter -= Time.deltaTime;
    }

    public void MoveCardAsset(int from, int to)
    {
        prefab = Resources.Load<GameObject>("Prefabs/Asset");
        parent = GameObject.Find("Animation");
        card = Card.cards[from];
        startSet = Card.Cards[from];
        endSet = Asset.Assets[to];

        prefab.GetComponentInChildren<Image>().sprite = Card.Cards[from].GetComponentInChildren<Image>().sprite;
        prefab.GetComponentInChildren<Text>().text = Card.Cards[from].GetComponentInChildren<Text>().text;
        prefab.GetComponentInChildren<Text>().color = Card.Cards[from].GetComponentInChildren<Text>().color;
        prefab.GetComponentInChildren<Image>().color = Card.Cards[from].GetComponentInChildren<Image>().color;

        prefab = Instantiate(prefab, startSet.transform.position, startSet.transform.rotation, parent.transform);

        card.RemoveCard(from);
    }
}
