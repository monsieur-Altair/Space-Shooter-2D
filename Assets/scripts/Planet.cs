using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMove;
    public float speed;
    Vector2 min;
    Vector2 max;

    void Start()
    {
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        max.y += GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        min.y -= GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }
    void Update()
    {
        if (!isMove)
            return;

        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);
        transform.position = pos;

        if (pos.y < min.y)
            isMove = false;
    }
    public void ResetPosition()
    {
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
