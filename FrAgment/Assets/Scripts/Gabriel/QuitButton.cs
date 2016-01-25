using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitButton : MonoBehaviour
{
    public GameObject GlobalScripts;
    Color colour;

    public float FadeSpeed;
    // Use this for initialization
    void Start()
    {
        colour = this.GetComponent<Image>().color;
        colour.a = 0;
        this.GetComponent<Image>().color = colour;

        this.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalScripts.GetComponent<GameRuntimeHandler>().GAME_STATE == GameRuntimeHandler.GAME_STATES.PAUSED)
        {
            if (colour.a < 1)
            {
                this.GetComponent<Button>().interactable = true;
                colour.a += FadeSpeed * GlobalScripts.GetComponent<GameRuntimeHandler>().getDeltaTimeUnpaused();
                this.GetComponent<Image>().color = colour;
            }
        }
        else
        {
            if (colour.a > 0)
            {
                colour.a -= FadeSpeed * GlobalScripts.GetComponent<GameRuntimeHandler>().getDeltaTimeUnpaused();
                this.GetComponent<Image>().color = colour;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
    }
}
