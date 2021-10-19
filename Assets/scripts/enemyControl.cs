using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyControl : MonoBehaviour
{
    private float speed;
    public GameObject ExplosionPrefab;
    GameObject textScore; 
    void Start()
    {
        speed = 2f;
        textScore = GameObject.FindGameObjectWithTag("TextScoreTag");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag" || collision.tag == "PlayerBulletTag")
        {
            PlayExplosion();
            textScore.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
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
