using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHighscore : MonoBehaviour
{
    public bool isTextMesh;
    // Use this for initialization
    void Start()
    {
        if(isTextMesh)
        {
            this.GetComponent<TextMesh>().text = GameData.i_HighScore.ToString();
        }
        else
        {
            this.GetComponent<Text>().text = GameData.i_HighScore.ToString();
        }
    }
    /*
    // Update is called once per frame
    void Update()
    {

    }*/
}
