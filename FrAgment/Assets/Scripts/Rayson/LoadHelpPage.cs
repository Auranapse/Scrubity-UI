using UnityEngine;
using System.Collections;

public class LoadHelpPage : MonoBehaviour
{

    bool isLoaded;
    bool isClicked;
    bool inProgress;

    float Timer;

    Vector3 Temp;
    // Use this for initialization
    void Start()
    {
        isLoaded = false;
        isClicked = false;
        inProgress = false;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked == true && isLoaded == false)
        {
            Timer += Time.deltaTime;
            if (Timer > 0)
            {
                GameObject.Find("FadeOutBox").GetComponent<Fading>().isFadeOut = false;
                GameObject.Find("FadeOutBox").GetComponent<Fading>().isFadeIn = true;
                Temp.Set(-350, -580, 0);
                GameObject.Find("ShipIcon").GetComponent<Translation>().EndPos = Temp;
            }
            if (Timer > 1)
            {
                Temp.Set(0, 1350, 0);
                GameObject.Find("HelpPage").GetComponent<Translation>().EndPos = Temp;
            }

            if (Timer > 2)
            {
                Temp.Set(0, 550, 0);
                GameObject.Find("HelpTopBlackBox").GetComponent<Translation>().EndPos = Temp;
                Temp.Set(0, -600, 0);
                GameObject.Find("HelpBotBlackBox").GetComponent<Translation>().EndPos = Temp;
            }

            if (Timer > 3)
            {


                GameObject.Find("Ship").GetComponent<Fading>().isFadeIn = true;
                GameObject.Find("Ship").GetComponent<Fading>().isFadeOut = false;

                GameObject.Find("Asteroid").GetComponent<Fading>().isFadeIn = true;
                GameObject.Find("Asteroid").GetComponent<Fading>().isFadeOut = false;

            }
            if (Timer > 4)
            {

                GameObject.Find("Instructions").GetComponent<Fading>().isFadeOut = false;
                GameObject.Find("Instructions").GetComponent<Fading>().isFadeIn = true;
            }
            if (Timer > 4)
            {
                isLoaded = true;
                inProgress = false;
                Timer = 0;
            }

        }
        if (isClicked == false && isLoaded == true)
        {
            inProgress = true;
            Timer += Time.deltaTime;

            if (Timer > 0)
            {

                GameObject.Find("Ship").GetComponent<Fading>().isFadeOut = true;
                GameObject.Find("Ship").GetComponent<Fading>().isFadeIn = false;

                GameObject.Find("Asteroid").GetComponent<Fading>().isFadeOut = true;
                GameObject.Find("Asteroid").GetComponent<Fading>().isFadeIn = false;

                GameObject.Find("Instructions").GetComponent<Fading>().isFadeOut = true;
                GameObject.Find("Instructions").GetComponent<Fading>().isFadeIn = false;
            }

            if (Timer > 1)
            {
                Temp.Set(0, 550, 0);
                GameObject.Find("HelpTopBlackBox").GetComponent<Translation>().EndPos = GameObject.Find("HelpTopBlackBox").GetComponent<Translation>().InitialPos;
                Temp.Set(0, -600, 0);
                GameObject.Find("HelpBotBlackBox").GetComponent<Translation>().EndPos = GameObject.Find("HelpBotBlackBox").GetComponent<Translation>().InitialPos;
            }
            if (Timer > 2)
            {

                GameObject.Find("HelpPage").GetComponent<Translation>().EndPos = GameObject.Find("HelpPage").GetComponent<Translation>().InitialPos;
            }
            if (Timer > 3.5)
            {

                GameObject.Find("ShipIcon").GetComponent<Translation>().EndPos = GameObject.Find("ShipIcon").GetComponent<Translation>().InitialPos;

                GameObject.Find("FadeOutBox").GetComponent<Fading>().isFadeOut = true;
                GameObject.Find("FadeOutBox").GetComponent<Fading>().isFadeIn = false;


            }
            if (Timer > 4)
            {
                isLoaded = false;
                inProgress = false;
                Timer = 0;
                
            }


        }
        
    }
    public void ChangeClickedState()
    {
        if (GameObject.Find("Help Button").GetComponent<LoadHelpPage>().inProgress == false)
        {
            Debug.Log("test");
            GameObject.Find("Help Button").GetComponent<LoadHelpPage>().isClicked = !isClicked;

            GameObject.Find("Help Button").GetComponent<LoadHelpPage>().inProgress = true;
        }

    }
}
