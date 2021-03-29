using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject playerPrefab;
    public Text scoreText;
    public Text ballsText;
    public Text levelText;
    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;

    public enum State { MENU, LOADLEVEL, PLAY, INIT, GAMEOVER, LEVELCOMPLETE }
    State pstate;

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(State.MENU);
    }

    public void SwitchState(State newState)
    {
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panelMenu.SetActive(true);
                break;
            case State.LOADLEVEL:
                break;
            case State.PLAY:
                break;
            case State.INIT:
                break;
            case State.GAMEOVER:
                break;
            case State.LEVELCOMPLETE:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (pstate)
        {
            case State.MENU:
                break;
            case State.LOADLEVEL:
                break;
            case State.PLAY:
                break;
            case State.INIT:
                break;
            case State.GAMEOVER:
                break;
            case State.LEVELCOMPLETE:
                break;
        }
    }

    void EndState()
    {
        switch (pstate)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.PLAY:
                break;
            case State.INIT:
                break;
            case State.GAMEOVER:
                break;
            case State.LEVELCOMPLETE:
                break;
        }
    }
}
