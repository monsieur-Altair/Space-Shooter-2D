using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public float speed;
    private const float PlayerSizeY = 0.57f;
    private const float PlayerSizeX = 0.45f;
    public GameObject bulletPrefab;
    public GameObject bulletPos01;
    public GameObject bulletPos02;
    public GameObject ExplosionPrefab;
    public Text livesText;
    public GameObject GameManagerGO;
    AudioSource audioSource;

    private int lives;
    const int maxLives = 3;

    public void Init()
    {
        gameObject.transform.position = new Vector2(0, 0);
        lives = maxLives;
        livesText.text = lives.ToString();
        gameObject.SetActive(true);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
        if(Input.GetKeyDown("space"))
        {
            audioSource.Play();
            GameObject bullet01 = Instantiate(bulletPrefab);
            bullet01.transform.position = bulletPos01.transform.position;
            GameObject bullet02 = Instantiate(bulletPrefab);
            bullet02.transform.position = bulletPos02.transform.position;
        }
    }

    private void Move(Vector2 direction)
    {
        //определяем границы экрана
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//левый нижний
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//верхний правый угол

        min.x += PlayerSizeX / 2;
        max.x -= PlayerSizeX / 2;

        min.y += PlayerSizeY / 2;
        max.y -= PlayerSizeY / 2;

        Vector2 position = transform.position;
        position += direction * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);

        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="BossTag")
        {
            PlayExplosion();
            GameManagerGO.GetComponent<GameManager>().SetGMState(GameManager.GameManagerState.GAMEOVER);
            gameObject.SetActive(false);
        }
        if (collision.tag == "EnemyTag" || collision.tag == "EnemyBulletTag")
        {
            PlayExplosion();
            lives--;
            livesText.text = lives.ToString();
            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGMState(GameManager.GameManagerState.GAMEOVER);
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }
    }
    private void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
    }
}
