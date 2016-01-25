using UnityEngine;
using System.Collections;

public class MainMenuToChallenge : MonoBehaviour {

    bool StartAnimation;

    bool UIAnim_Done, TopBoxAnim_D, BotBoxAnim_D;

    private RectTransform TopBox, BotBox, UI;

    Vector3 UI_EndScale;
    Vector3 UI_ScaleSpeed;

    Vector3 TopBoxRotation, BotBoxRotation;

    // Use this for initialization
    void Start()
    {
        StartAnimation = false;
        UIAnim_Done = false;
        TopBoxAnim_D = false;
        BotBoxAnim_D = false;
        TopBox = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();
        BotBox = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
        UI = GameObject.Find("User Interface").GetComponent<RectTransform>();
        UI_EndScale.Set(0.1f, 0.1f, 0);
        UI_ScaleSpeed.Set(0.02f, 0.02f, 0);
        TopBoxRotation.Set(0, 0, 1f);
        BotBoxRotation.Set(0, 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartAnimation == true)
        {
            //remove UI
            if (UI.localScale.x > UI_EndScale.x || UI.localScale.y > UI_EndScale.y)
            {
                UI.localScale -= UI_ScaleSpeed;

                Debug.Log(UI.localScale);
            }
            else
            {
                UIAnim_Done = true;
            }
            if (TopBox.localEulerAngles.z < 180)
            {
                TopBox.localEulerAngles += TopBoxRotation;
            }
            else
            {
                TopBoxRotation.Set(0, 0, 180);
                TopBox.localEulerAngles = TopBoxRotation;
                TopBoxAnim_D = true;
            }

            if (BotBox.localEulerAngles.z > 180)
            {
                BotBox.localEulerAngles -= BotBoxRotation;
            }
            else
            {
                BotBoxRotation.Set(0, 0, 180);
                BotBox.localEulerAngles = BotBoxRotation;
                BotBoxAnim_D = true;
            }
        }
        if (TopBoxAnim_D == true && UIAnim_Done == true && BotBoxAnim_D == true)
        {
            StartAnimation = false;
            Application.LoadLevel("ChallengeScreen");
        }
    }
    public void RePositionForNextScene(bool Execute)
    {
        GameObject.Find("GlobalFunctions").GetComponent<MainMenuToChallenge>().StartAnimation = Execute;
    }
}
