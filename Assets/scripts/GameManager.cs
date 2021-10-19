using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject buttonPlay;
    public GameObject player;
    public GameObject spawner;
    public GameObject GameOverGO;
    public GameObject textScoreUI;
    public GameObject timeCounter;
    public GameObject gameTitle;
    private float repeatTime = 5f;
    public enum GameManagerState
    {
        OPENING,
        GAMEPLAY,
        GAMEOVER
    }
    GameManagerState GMState;
    void Start()
    {
        GMState = GameManagerState.OPENING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGMState()
    {
        switch (GMState)
        {
            case GameManagerState.OPENING:
                buttonPlay.SetActive(true);
                GameOverGO.SetActive(false);
                gameTitle.SetActive(true);
                break;
            case GameManagerState.GAMEPLAY:
                gameTitle.SetActive(false);
                buttonPlay.SetActive(false);
                timeCounter.GetComponent<TimeCounter>().StartTimeCounter();
                textScoreUI.GetComponent<GameScore>().Score = 0;
                player.GetComponent<playerControl>().Init();
                spawner.GetComponent<enemySpawner>().StartSpawn();
                break;
            case GameManagerState.GAMEOVER:
                timeCounter.GetComponent<TimeCounter>().StopTimeCounter();
                GameOverGO.SetActive(true);
                spawner.GetComponent<enemySpawner>().StopSpawn();
                Invoke("ChangeToOpening", repeatTime);
                break;
        }
    }
    public void SetGMState(GameManagerState state)
    {
        GMState = state;
        UpdateGMState();
    }

    public void StartGamePlay()
    {
        SetGMState(GameManagerState.GAMEPLAY);
    }
    public void ChangeToOpening()
    {
        SetGMState(GameManagerState.OPENING);
    }
}
    