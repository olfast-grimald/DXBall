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
    public GameObject[] levels;
    //public Text nameText;

    public static GameManager Instance { get; private set; }

    public enum State { MENU, LOADLEVEL, PLAY, INIT, GAMEOVER, LEVELCOMPLETE }
    State pstate;
    GameObject pcurrentball;
    GameObject pcurrentlevel;
    bool pisSwitchingStates;

    //updates these values only when there's a change/setting in them, instead of updating the values in every loop
    private int pscore;

    public int Score
    {
        get { return pscore; }
        set { pscore = value;
            scoreText.text = "SCORE: " + pscore;
        }
    }

    private int plevel;

    public int Level
    {
        get { return plevel; }
        set { plevel = value;
            levelText.text = "LEVEL: " + plevel;
        }
    }

    private int pballs;

    public int Balls
    {
        get { return pballs; }
        set { pballs = value;
            ballsText.text = "BALLS: " + pballs;
        }
    }


    public void playClicked()
    {
        SwitchState(State.INIT);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
    }

    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        pisSwitchingStates = true;
        yield return new WaitForSeconds(delay);
        //i can't believe i forgot to call the methods and broke my head over whu the buttons won't work for TWO WHOLE DAYS
        EndState();
        pstate = newState;
        BeginState(newState);
        pisSwitchingStates = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panelMenu.SetActive(true);
                Cursor.visible = true;
                // ples work 
                break;
            case State.LOADLEVEL:
                if(Level >= levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    pcurrentlevel = Instantiate(levels[Level]);
                    SwitchState(State.PLAY);
                }
                break;
            case State.PLAY:
                break;
            case State.INIT:
                Cursor.visible = false;
                panelPlay.SetActive(true);
                Score = 0;
                Level = 1;
                Balls = 3;
                if (pcurrentlevel != null)
                {
                    Destroy(pcurrentlevel);
                }
                //to bring a prefab into the scene:
                Instantiate(playerPrefab);
                SwitchState(State.LOADLEVEL);
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;
            case State.LEVELCOMPLETE:
                Destroy(pcurrentball);
                Destroy(pcurrentlevel);
                Level++;
                SwitchState(State.LOADLEVEL, 2f);
                panelLevelCompleted.SetActive(true);
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
                if (pcurrentball == null)
                {
                    if (Balls > 0)
                    {
                        pcurrentball = Instantiate(ballPrefab);
                    }
                    else
                    {
                        SwitchState(State.GAMEOVER);
                    }
                }
                if (pcurrentlevel != null && pcurrentlevel.transform.childCount == 0 && !pisSwitchingStates)
                {
                    SwitchState(State.LEVELCOMPLETE);
                }
                break;
            case State.INIT:
                break;
            case State.GAMEOVER:
                if (Input.anyKeyDown)
                {
                    SwitchState(State.MENU);
                }
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
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
            case State.LEVELCOMPLETE:
                panelLevelCompleted.SetActive(false);
                break;
        }
    }
}
