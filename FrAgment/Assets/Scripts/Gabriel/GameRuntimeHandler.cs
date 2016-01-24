using UnityEngine;
using System.Collections;

public class GameRuntimeHandler : MonoBehaviour
{
    float f_GAME_TIMER;
    bool b_isGameReady;
    // Use this for initialization

    public enum GAME_STATES
    {
        INTRO,
        PLAYING,
        PAUSED,
    };

    public GAME_STATES GAME_STATE;

    void Start()
    {
        f_GAME_TIMER = 0f;
        b_isGameReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        f_GAME_TIMER += Time.deltaTime;
    }

    public float getRuntime()
    {
        return f_GAME_TIMER;
    }

    public void setReadytobegin()
    {
        b_isGameReady = true;
    }

    public bool isGameReady()
    {
        return b_isGameReady;
    }
}
