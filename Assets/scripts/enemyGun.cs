using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
 
    void Start()
    {
        Invoke("Fire", 1f);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Fire()
    {
        GameObject player = GameObject.Find("playerGO");
        if(player)
        {
            GameObject enemyBullet = Instantiate(enemyBulletPrefab);
            enemyBullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - enemyBullet.transform.position;
            enemyBullet.GetComponent<enemyBulletControl>().SetDirection(direction);
        }
    }
}
