using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
    private static GameData instance = null;

    public static GameData Instance
    {
        get { return instance; }
    }

    public static int i_HighScore;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

        if (!PlayerPrefs.HasKey("GAMEPLAY_HIGHSCORE"))
        {
            PlayerPrefs.SetInt("GAMEPLAY_HIGHSCORE", 0);
        }

        i_HighScore = PlayerPrefs.GetInt("GAMEPLAY_HIGHSCORE");
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
