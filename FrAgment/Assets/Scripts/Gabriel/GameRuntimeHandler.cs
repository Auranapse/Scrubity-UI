using UnityEngine;
using System.Collections;

public class GameRuntimeHandler : MonoBehaviour
{
    float f_GAME_TIMER;
    public float f_EnemySpawnRate;
    float f_EnemySpawner;
    bool b_isGameReady;
    // Use this for initialization
    public GameObject Enemy2;

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
        f_EnemySpawner = 0f;
        f_GAME_TIMER = 0f;
        b_isGameReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        f_GAME_TIMER += Time.deltaTime;

        switch (GAME_STATE)
        {
            case GAME_STATES.PLAYING:
                {
                    if (f_EnemySpawnRate < f_EnemySpawner)
                    {
                        f_EnemySpawner = 0f;
                        GameObject temp = (GameObject)Instantiate(Enemy2, new Vector3(Random.Range(-350, 350), Random.Range(750, 850), 0), this.transform.rotation);
                        temp.SetActive(true);
                        temp.GetComponent<Enemies>().i_Health = 8;
                    }
                    else
                    {
                        f_EnemySpawner += Time.deltaTime;
                    }
                }
                break;
            case GAME_STATES.DEATH:
                {
                    
                }
                break;
        }
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
