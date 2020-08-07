using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    public static GameObject startSet;
    public static GameObject prefab;
    public static GameObject parent;

    private static float counterSet;
    private float counterStart;
    private float counter;

    private void Awake()
    {
        counter = counterSet;
        counterStart = counterSet;
    }

    void Update()
    {
        if (counter > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (0.003f / counterStart));
        }

        else if (counter <= 0)
        {
            Destroy(gameObject);
        }

        counter -= Time.deltaTime;
    }

    public void DisplayText(GameObject i, string text, Color color, float sec)
    {
        prefab = Resources.Load<GameObject>("Prefabs/Text");
        parent = GameObject.Find("Animation");
        startSet = i;

        counterSet = sec;

        prefab.GetComponentInChildren<Text>().text = text;
        prefab.GetComponentInChildren<Text>().color = color;

        prefab = Instantiate(prefab, startSet.transform.position, startSet.transform.rotation, parent.transform);
    }
}
