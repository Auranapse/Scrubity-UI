using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScreenText : MonoBehaviour
{
    TextMesh TM_Text;
    Color colour;
    bool b_display;
    bool b_isDone;
    bool b_pernament;
    float displaytime;
    public float FadeSpeed;
    public GameObject GlobalScripts;

    // Use this for initialization
    void Start()
    {
        TM_Text = this.GetComponent<TextMesh>();
        colour = TM_Text.color;

        colour.a = 0;
        TM_Text.color = colour;

        b_pernament = false;
        b_display = false;
        b_isDone = false;
        displaytime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(b_pernament)
        {
            if (colour.a < 1)
            {
                colour.a += FadeSpeed * GlobalScripts.GetComponent<GameRuntimeHandler>().getDeltaTimeUnpaused();
                TM_Text.color = colour;
            }
        }
        else
        {
            if (b_display)
            {
                if (colour.a < 1)
                {
                    colour.a += FadeSpeed * GlobalScripts.GetComponent<GameRuntimeHandler>().getDeltaTimeUnpaused();
                    TM_Text.color = colour;
                }
                else
                {
                    displaytime -= GlobalScripts.GetComponent<GameRuntimeHandler>().getDeltaTimeUnpaused();

                    if (displaytime <= 0)
                    {
                        b_display = false;
                    }
                }
            }
            else
            {
                if (colour.a > 0)
                {
                    colour.a -= FadeSpeed * GlobalScripts.GetComponent<GameRuntimeHandler>().getDeltaTimeUnpaused();
                    TM_Text.color = colour;
                }
                else
                {
                    b_isDone = true;
                }
            }
        }
    }

    public bool isDoneDisplaying()
    {
        return b_isDone;
    }

    public void Display(float duration, string text)
    {
        b_isDone = false;
        b_display = true;
        displaytime = duration;
        TM_Text.text = text;
    }

    public void DisplayPernament(string text)
    {
        b_isDone = false;
        b_pernament = true;
        TM_Text.text = text;
    }

    public void unDisplayPernament()
    {
        b_display = false;
        b_isDone = false;
        b_pernament = false;
    }
}
