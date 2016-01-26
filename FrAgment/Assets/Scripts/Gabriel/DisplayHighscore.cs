using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHighscore : MonoBehaviour
{
    public bool isTextMesh;
    public bool DisplayNormalScoreInstead;
    // Use this for initialization
    void Start()
    {
        if(DisplayNormalScoreInstead)
        {
            if (isTextMesh)
            {
                this.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("GAMEPLAY_SCORE").ToString();
            }
            else
            {
                this.GetComponent<Text>().text = PlayerPrefs.GetInt("GAMEPLAY_SCORE").ToString();
            }
        }
        else
        {
            if (isTextMesh)
            {
                this.GetComponent<TextMesh>().text = GameData.i_HighScore.ToString();
            }
            else
            {
                this.GetComponent<Text>().text = GameData.i_HighScore.ToString();
            }
        }
    }
    /*
    // Update is called once per frame
    void Update()
    {

    }*/
}
