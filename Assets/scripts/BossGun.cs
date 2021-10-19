using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    public GameObject enemyBulletPrefab;

    void Start()
    {
        InvokeRepeating("Fire", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Fire()
    {
        GameObject player = GameObject.Find("playerGO");
        if (player)
        {
            for (int i = -3; i < 4; i++)
            {
                GameObject enemyBullet = Instantiate(enemyBulletPrefab);
                enemyBullet.transform.position = transform.position;
                Vector2 playerDirection = player.transform.position;
                playerDirection = new Vector2(playerDirection.x + i*1.3f , playerDirection.y);
                Vector2 enemyBulletPosition = enemyBullet.transform.position;
                Vector2 direction = playerDirection - enemyBulletPosition;
                enemyBullet.GetComponent<enemyBulletControl>().SetDirection(direction);
            }
        }
    }
}
