using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
    public GameObject FunctionCall;
    float f_Timer;
    int i_Score;
    int i_HighScore;
    TextMesh TEXTDISPLAY;

    // Use this for initialization
    void Start()
    {
        f_Timer = 5f;
        i_Score = 0;
        i_HighScore = GameData.i_HighScore;
        TEXTDISPLAY = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (FunctionCall.GetComponent<GameRuntimeHandler>().GAME_STATE)
        {
            case GameRuntimeHandler.GAME_STATES.INTRO:
                {
                    if (FunctionCall.GetComponent<GameRuntimeHandler>().isGameReady())
                    {
                        f_Timer -= Time.deltaTime;
                    }
                    if (f_Timer <= 0)
                    {
                        FunctionCall.GetComponent<GameRuntimeHandler>().GAME_STATE = GameRuntimeHandler.GAME_STATES.PLAYING;
                    }

                    TEXTDISPLAY.text = ((int)f_Timer).ToString();
                }
                break;
            case GameRuntimeHandler.GAME_STATES.PLAYING:
                {
                    f_Timer += Time.deltaTime;
                    if (f_Timer > 1)
                    {
                        i_Score += 1;
                        f_Timer = 0;
                    }
                    
                    TEXTDISPLAY.text = i_Score.ToString();
                }
                break;
            case GameRuntimeHandler.GAME_STATES.PAUSED:
                {
                    TEXTDISPLAY.text = "PAUSED";
                }
                break;
            case GameRuntimeHandler.GAME_STATES.DEATH:
                {
                    if(i_Score > i_HighScore)
                    {
                        i_HighScore = i_Score;
                        GameData.i_HighScore = i_HighScore;
                        PlayerPrefs.SetInt("GAMEPLAY_HIGHSCORE", GameData.i_HighScore);
                    }

                    PlayerPrefs.SetInt("GAMEPLAY_SCORE", i_Score);
                }
                break;
        }
    }

    public void AddScore(int amount)
    {
        i_Score = i_Score + amount;
    }

    public void resetScore()
    {
        i_Score = 0;
    }
}
