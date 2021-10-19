using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLBulletControl : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyTag"||collision.tag=="BossTag")
            Destroy(gameObject);
    }
    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y + speed * Time.deltaTime);
        //pos+=new Vector2(0,speed*Time.deltaTime);
        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if(transform.position.y>max.y)
        {
            Destroy(gameObject);
        }
    }
}
