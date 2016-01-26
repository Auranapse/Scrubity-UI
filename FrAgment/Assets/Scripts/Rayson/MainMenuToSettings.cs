using UnityEngine;
using System.Collections;

public class MainMenuToSettings : MonoBehaviour {

    bool StartAnimation;

    bool UI_Anim_D, TopBoxAnim_D, BotBoxAnim_D;

    private RectTransform TopBox,BotBox;

    Vector3 UI_EndScale;
    Vector3 UI_ScaleSpeed;

    Vector3 TopBoxRotation,BotBoxRotation;

    private GameObject UI;
    float Timer;
	// Use this for initialization
	void Start () {
        Timer = 0;
        StartAnimation = false;
        UI_Anim_D = false;
        TopBoxAnim_D = false;
        BotBoxAnim_D = false;
        TopBox = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();
        BotBox = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
        UI_EndScale.Set(0.1f, 0.1f, 0);
        UI_ScaleSpeed.Set(0.02f, 0.02f, 0);
        TopBoxRotation.Set(0,0,1f);
        BotBoxRotation.Set(0, 0, 1f);
    }

    // Update is called once per frame
    void Update () {
        Timer += Time.deltaTime;

        if (StartAnimation == true)
        {
            //remove UI
            if (Timer > 0)
            {
                UI = GameObject.Find("Title");
                UI.GetComponent<Translation>().EndPos = UI.GetComponent<Translation>().InitialPos;

                UI = GameObject.Find("Start Button");
                UI.GetComponent<Translation>().EndPos = UI.GetComponent<Translation>().InitialPos;

                UI = GameObject.Find("Survival Button");
                UI.GetComponent<Translation>().EndPos = UI.GetComponent<Translation>().InitialPos;

                UI = GameObject.Find("Settings Button");
                UI.GetComponent<Translation>().EndPos = UI.GetComponent<Translation>().InitialPos;

                UI = GameObject.Find("Zen Button");
                UI.GetComponent<Translation>().EndPos = UI.GetComponent<Translation>().InitialPos;

                UI = GameObject.Find("Help Button");
                UI.GetComponent<Translation>().EndPos = UI.GetComponent<Translation>().InitialPos;
                UI_Anim_D = true;
            }
            else
            {
                UI_Anim_D = true;
            }
            if (TopBox.localEulerAngles.z < 200)
            {
                TopBox.localEulerAngles += TopBoxRotation * Time.deltaTime * 120;
            }
            else
            {
                TopBoxRotation.Set(0, 0, 200);
                TopBox.localEulerAngles = TopBoxRotation;
                TopBoxAnim_D = true;
            }

            if (BotBox.localEulerAngles.z > 161)
            {
                BotBox.localEulerAngles -= BotBoxRotation * Time.deltaTime * 120;
            }
            else
            {
                BotBoxRotation.Set(0, 0, 160);
                BotBox.localEulerAngles = BotBoxRotation;
                BotBoxAnim_D = true;
            }
        }
        if (TopBoxAnim_D == true && UI_Anim_D == true && BotBoxAnim_D == true)
        {
            StartAnimation = false;
            Application.LoadLevel("OptionScreen_Control");
        }
    }
    public void RePositionForNextScene(bool Execute)
    {
        GameObject.Find("GlobalFunctions").GetComponent<MainMenuToSettings>().StartAnimation = Execute;
    }
}
