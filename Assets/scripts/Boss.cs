using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float speed;
    public GameObject ExplosionPrefab;
    GameObject textScore;
    int hp;
    void Start()
    {
        speed = 0.3f;
        textScore = GameObject.FindGameObjectWithTag("TextScoreTag");
        hp = 15;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "PlayerTag")
        //{ 

        //}
        if(collision.tag == "PlayerBulletTag")
        {
            if (hp != 0)
                hp--;
            else
            {
                PlayExplosion();
                textScore.GetComponent<GameScore>().Score += 10000;
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);
        transform.position = pos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
            Destroy(gameObject);
    }
    private void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
    }
}
