using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletControl : MonoBehaviour
{
    private Vector2 _direction;
    private bool isReady;
    private float speed;

    void Awake()
    {
        isReady = false;
        speed = 5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            Vector2 pos = transform.position;
            pos += _direction * speed * Time.deltaTime;
            transform.position = pos;

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            if(pos.x>max.x||pos.x<min.x||
               pos.y>max.y||pos.y<min.y)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
}
