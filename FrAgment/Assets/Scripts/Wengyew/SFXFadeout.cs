using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SFXFadeout : MonoBehaviour {
    public string SceneToChangeTo;

    private bool startAnim;
    private bool startMenuAnim;

    private RectTransform optionsContainer;
    private CanvasGroup SoundTypeGroup;

    private CanvasGroup curSquare;
    private CanvasGroup targetSquare;

    private RectTransform settingsText;
    private RectTransform topBox;
    private RectTransform btmBox;

    private CanvasGroup settingsSquare;
    private CanvasGroup backBtn;

	// Use this for initialization
	void Start () {
        startAnim = false;
        startMenuAnim = false;

        optionsContainer = GameObject.Find("Volume Options").GetComponent<RectTransform>();
        SoundTypeGroup = GameObject.Find("Sound Type Buttons").GetComponent<CanvasGroup>();

        curSquare = GameObject.Find("BottomBtn").GetComponent<CanvasGroup>();
	}

    Vector3 topR, botR;
    Vector3 stupidUnity;
    bool wtfUnityFloats, annoying;
    // Update is called once per frame
	void Update () {
        if (startAnim)
        {
            // Get options out of the way
            Vector3 translate = optionsContainer.localPosition;
            translate.y = Mathf.Lerp(translate.y, -400, Time.deltaTime * 8);
            optionsContainer.localPosition = translate;

            //Transition square opacity
            curSquare.alpha = Mathf.Lerp(curSquare.alpha, 0.3f, Time.deltaTime * 12);
            if (targetSquare != null)
                targetSquare.alpha = (Mathf.Lerp(targetSquare.alpha, 1.0f, Time.deltaTime * 10));

            //Fade box out
            SoundTypeGroup.alpha = (Mathf.Lerp(SoundTypeGroup.alpha, 0.0f, Time.deltaTime * 13));

            if (optionsContainer.localPosition.y < -211)
            {
                startAnim = false;
                if (SceneToChangeTo == "MenuScreen")
                {
                    Debug.Log("Start menu transitioning");
                    startMenuAnim = true;
                }
                else
                {
                    Application.LoadLevel(SceneToChangeTo);
                    Debug.Log("Loading " + SceneToChangeTo);
                }
            }
        }
        if (startMenuAnim)
        {
            // Make sure sound buttons are transparent.
            SoundTypeGroup.alpha = 0;

            //Move settings out
            Vector3 translate = settingsText.localPosition;
            translate.x = Mathf.Lerp(translate.x, -900, Time.deltaTime * 10);
            settingsText.localPosition = translate;

            topR.Set(0, 0, -1);
            botR.Set(0, 0, 1);

            //blackbox
            if (topBox.localEulerAngles.z > 160.1f)
                topBox.localEulerAngles += topR * Time.deltaTime * 120;
            else
            {
                stupidUnity.Set(0, 0, 160);
                topBox.localEulerAngles = stupidUnity;
                wtfUnityFloats = true;
            }

            if (btmBox.localEulerAngles.z < 200)
            {
                btmBox.localEulerAngles += botR * Time.deltaTime * 120;
            }
            else
            {
                stupidUnity.Set(0, 0, 200);
                btmBox.localEulerAngles = stupidUnity;
                annoying = true;
            }     

            //Fade out squares + back btn
            settingsSquare.alpha = (Mathf.Lerp(settingsSquare.alpha, 0.0f, Time.deltaTime * 13));
            backBtn.alpha = (Mathf.Lerp(backBtn.alpha, 0.0f, Time.deltaTime * 13));

            if (wtfUnityFloats && annoying)
            {
                Application.LoadLevel(SceneToChangeTo);
                Debug.Log("Loading Menu");
            }
            else
            {
                Debug.Log(topBox.localEulerAngles.z + " " + btmBox.localEulerAngles.z);
            }
        }
	}

    public void startFadeoutAnim()
    {
        tracker.SceneToChangeTo = SceneToChangeTo;
        initSFXSettingsScreen.initialiseElements = false;
        startAnim = true;

        PlayerPrefs.SetInt("renderHelp?", 1);

        if (SceneToChangeTo == "OptionScreen_Control")
        {
            targetSquare = GameObject.Find("TopBtn").GetComponent<CanvasGroup>();
            Debug.Log("Start UI Fadeout animation to CTRL Screen");
        }
        else if (SceneToChangeTo == "OptionScreen_UI")
        {
            targetSquare = GameObject.Find("MiddleBtn").GetComponent<CanvasGroup>();
            Debug.Log("Start UI Fadeout animation to UI Screen");
        }
        else if (SceneToChangeTo == "MenuScreen")
        {
            targetSquare = null;

            settingsText = GameObject.Find("Settings").GetComponent<RectTransform>();
            topBox = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();
            btmBox = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
            settingsSquare = GameObject.Find("Settings Pages").GetComponent<CanvasGroup>();
            backBtn = GameObject.Find("Back Button").GetComponent<CanvasGroup>();

            Debug.Log("Start SFX fadeout animation to Menu Screen");
        }
    }
}
