using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarPrefab;
    public int maxStarCount;

    Color[] starColors =
    {
        new Color(1f, 0, 0, 1f),  //red
        new Color(0, 1f, 0, 1f),  //green
        new Color(0f, 1f, 1, 1f), //blue
        new Color(1f, 0.92f, 0.016f, 1f) //yellow
    };

    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i=0;i<maxStarCount;i++)
        {
            GameObject star = Instantiate(StarPrefab);
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            star.GetComponent<StarController>().speed = 1f * Random.value + 0.5f;
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
