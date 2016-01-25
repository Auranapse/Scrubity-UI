using UnityEngine;
using System.Collections;

public class MainMenuToHelpScreen : MonoBehaviour {
 enum Steps
    {
        S_FadeOut,
        S_BringInHelpScreen,
        S_BringBlackBoxesToScreen,
        S_BringInEntities,
        S_FadeInWWords,
        S_Animation_End
    }
    bool StartAnimation;

    private GameObject FadeOutBox,Ship,HelpPage,TopBlackBox,BotBlackBox,Ship2,Instructions,Asteroid,ReturnButton;

   
   


    Steps state;
    float Timer;
    // Use this for initialization
    void Start () {
        FadeOutBox = GameObject.Find("FadeOutBox");

        Ship = GameObject.Find("ShipIcon");
        HelpPage = GameObject.Find("HelpPage");

        TopBlackBox = GameObject.Find("HelpTopBlackBox");
        BotBlackBox = GameObject.Find("HelpBotBlackBox");

        Ship2 = GameObject.Find("Ship");
        Instructions = GameObject.Find("Instructions");
        Asteroid = GameObject.Find("Asteroid");

        ReturnButton = GameObject.Find("ReturnButton");

        state = Steps.S_FadeOut ;

        StartAnimation = false;

        Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (StartAnimation == true)
        {
            Timer += Time.deltaTime;
            switch (state)
            {
                case Steps.S_FadeOut:
                    FadeOutBox.GetComponent<Fading>().isFadeIn = true;
                    Ship.GetComponent<Translation>().enabled = true;
                    if (FadeOutBox.GetComponent<Fading>().isComplete == true)
                    {
                        state = Steps.S_BringInHelpScreen;

                    }
                    break;
                case Steps.S_BringInHelpScreen:
                    Ship.GetComponent<Translation>().enabled = false;
                    HelpPage.GetComponent<Translation>().enabled = true;
                    if (Timer > 2)
                    {
                        state = Steps.S_BringBlackBoxesToScreen;
                        Timer = 0;
                    }
                    break;
                case Steps.S_BringBlackBoxesToScreen:
                    TopBlackBox.GetComponent<Translation>().enabled = true;
                    BotBlackBox.GetComponent<Translation>().enabled = true;
                    if (Timer > 2)
                    {
                        state = Steps.S_BringInEntities;
                        Timer = 0;
                    }
                    break;
                case Steps.S_BringInEntities:

                    if (Timer > 0)
                    {
                        Ship2.GetComponent<Fading>().enabled = true;

                        Asteroid.GetComponent<Fading>().enabled = true;
                    }
                    if (Timer > 0.5)
                    {

                        Instructions.GetComponent<Fading>().enabled = true;
                    }
                    if (Timer > 1)
                    {

                        ReturnButton.GetComponent<Fading>().enabled = true;
                    }
                    break;
            }
        }
    }
    public void RePositionForNextScene(bool Execute)
    {
        GameObject.Find("GlobalFunctions").GetComponent<MainMenuToHelpScreen>().StartAnimation = Execute;
    }
}
