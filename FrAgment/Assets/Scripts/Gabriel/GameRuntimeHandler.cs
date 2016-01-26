using UnityEngine;
using System.Collections;

public class GameRuntimeHandler : MonoBehaviour
{
    float f_GAME_TIMER;
    public float f_EnemySpawnRate;
    int i_enemyHealth;
    float f_EnemySpawner;
    bool b_isGameReady;
    // Use this for initialization
    float f_tapTimer;
    int i_tapCount;
    int i_prevExitCount;
    int i_exitCount;
    public GameObject Enemy2;
    float f_pausedDT;
    float f_prevTime;
    float f_waittoexit;

    public string SceneToChangeToAtEndGame;

    public enum GAME_STATES
    {
        INTRO,
        PLAYING,
        PAUSED,
        DEATH,
    };

    public GAME_STATES GAME_STATE;

    void Start()
    {
        f_waittoexit = 0f;
        f_pausedDT = 0f;
        f_prevTime = Time.realtimeSinceStartup;
        i_tapCount = 0;
        i_exitCount = 0;
        i_prevExitCount = 0;
        f_tapTimer = 0f;
        f_EnemySpawner = 0f;
        f_GAME_TIMER = 0f;
        b_isGameReady = false;
        i_enemyHealth = Enemy2.GetComponent<Enemies>().i_Health;
    }

    // Update is called once per frame
    void Update()
    {
        f_GAME_TIMER += Time.deltaTime;

        if (f_tapTimer > 0)
        {
            f_tapTimer -= f_pausedDT;
        }

        switch (GAME_STATE)
        {
            case GAME_STATES.INTRO:
                {
                    if (!b_isGameReady)
                    {
                        GameObject.Find("ScreenText").GetComponent<GameScreenText>().Display(2, "Double tap to pause");
                    }
                    else
                    {
                        if (GameObject.Find("ScreenText").GetComponent<GameScreenText>().isDoneDisplaying())
                        {
                            GameObject.Find("ScreenText").GetComponent<GameScreenText>().Display(2, "Get ready!");
                        }
                    }
                }
                break;
            case GAME_STATES.PLAYING:
                {
                    if (f_EnemySpawnRate < f_EnemySpawner)
                    {
                        f_EnemySpawner = 0f;
                        GameObject temp = (GameObject)Instantiate(Enemy2, new Vector3(Random.Range(-350, 350), Random.Range(750, 850), 0), this.transform.rotation);
                        temp.SetActive(true);
                        temp.GetComponent<Enemies>().i_Health = i_enemyHealth;
                    }
                    else
                    {
                        f_EnemySpawner += Time.deltaTime;
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (f_tapTimer > 0)
                        {
                            if (i_tapCount == 1)
                            {
                                GameObject.Find("ScreenText").GetComponent<GameScreenText>().DisplayPernament("Double tap to resume");
                                i_exitCount = 0;
                                Time.timeScale = 0;
                                GAME_STATE = GAME_STATES.PAUSED;
                                i_tapCount = 0;
                            }
                        }
                        else
                        {
                            f_tapTimer = 0.2f;
                            i_tapCount = 1;
                        }
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (f_tapTimer <= 0)
                        {
                            i_tapCount = 0;
                        }
                    }
                }
                break;
            case GAME_STATES.PAUSED:
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (i_exitCount != 0 && i_exitCount == i_prevExitCount)
                        {
                            GameObject.Find("ScreenText").GetComponent<GameScreenText>().DisplayPernament("Double tap to resume");
                            i_exitCount = 0;
                            i_prevExitCount = 0;
                        }
                    }

                    if (i_exitCount >= 1)
                    {
                        i_prevExitCount = i_exitCount;

                        if (i_exitCount == 2)
                        {
                            GameObject.Find("ScreenText").GetComponent<GameScreenText>().DisplayPernament("Press quit 1 more time to quit");
                        }
                        else if (i_exitCount >= 3)
                        {
                            GameObject.Find("ScreenText").GetComponent<GameScreenText>().unDisplayPernament();
                            Time.timeScale = 1;
                            GAME_STATE = GAME_STATES.DEATH;
                        }
                        else
                        {
                            GameObject.Find("ScreenText").GetComponent<GameScreenText>().DisplayPernament("Press quit 2 more times to quit");
                        }
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (f_tapTimer > 0)
                        {
                            if (i_tapCount == 1)
                            {
                                GameObject.Find("ScreenText").GetComponent<GameScreenText>().unDisplayPernament();
                                GAME_STATE = GAME_STATES.PLAYING;
                                Time.timeScale = 1;
                                i_tapCount = 0;
                            }
                        }
                        else
                        {
                            f_tapTimer = 0.2f;
                            i_tapCount = 1;
                        }
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (f_tapTimer <= 0)
                        {
                            i_tapCount = 0;
                        }
                    }
                }
                break;
            case GAME_STATES.DEATH:
                {
                    f_waittoexit += Time.deltaTime;
                    if (f_waittoexit > 2)
                    {
                        changetoEndScreen();
                    }
                }
                break;
        }

        f_pausedDT = Time.realtimeSinceStartup - f_prevTime;
        f_prevTime = Time.realtimeSinceStartup;
    }

    public float getRuntime()
    {
        return f_GAME_TIMER;
    }

    public float getDeltaTimeUnpaused()
    {
        return f_pausedDT;
    }

    public void setReadytobegin()
    {
        b_isGameReady = true;
    }

    public bool isGameReady()
    {
        return b_isGameReady;
    }

    public void exitButton()
    {
        if (GAME_STATE == GAME_STATES.PAUSED)
        {
            ++i_exitCount;
        }
    }

    public void changetoEndScreen()
    {
        Application.LoadLevel(SceneToChangeToAtEndGame);
    }
}
