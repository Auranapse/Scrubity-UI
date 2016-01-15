using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class UIFadeout : MonoBehaviour {
    public string SceneToChangeTo;

    private bool startAnim;
    private bool startMenuAnim;

    private RectTransform optionsContainer;
    private CanvasGroup UIBox;

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

        optionsContainer = GameObject.Find("UI Color Options").GetComponent<RectTransform>();
        UIBox = GameObject.Find("UIBox").GetComponent<CanvasGroup>();

        curSquare = GameObject.Find("MiddleBtn").GetComponent<CanvasGroup>();
	}
	
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
            UIBox.alpha = (Mathf.Lerp(UIBox.alpha, 0.0f, Time.deltaTime * 13));

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
            // Make sure UIBox is transparent.
            UIBox.alpha = 0;

            //Move settings out
            Vector3 translate = settingsText.localPosition;
            translate.x = Mathf.Lerp(translate.x, -900, Time.deltaTime * 10);
            settingsText.localPosition = translate;

            // Rotate top black box
            Vector3 rotate = topBox.localEulerAngles;
            rotate.z = rotate.z - (Time.deltaTime * 140);
            if (rotate.z < 20) rotate.z += 360;
            if (rotate.z < 343.9929f)
            {
                rotate.z = 343.9929f;
            }
            else
            {
                topBox.localEulerAngles = rotate;
            }

            // Rotate bottom black box
            Vector3 rotate2 = btmBox.localEulerAngles;
            rotate2.z = rotate2.z + (Time.deltaTime * 220);
            if (rotate2.z > 320) rotate2.z -= 360;
            Debug.Log(rotate2.z);
            if (rotate2.z > 26.53186f)
            {
                rotate2.z = 26.53186f;
            }
            else
            {
                btmBox.localEulerAngles = rotate2;
            }

            //Fade out squares + back btn
            settingsSquare.alpha = (Mathf.Lerp(settingsSquare.alpha, 0.0f, Time.deltaTime * 13));
            backBtn.alpha = (Mathf.Lerp(backBtn.alpha, 0.0f, Time.deltaTime * 13));

            if (rotate.z == 343.9929f && rotate2.z == 26.53186f)
            {
                Application.LoadLevel(SceneToChangeTo);
                Debug.Log("Loading Menu");
            }
        }
	}

    public void startFadeoutAnim()
    {
        tracker.SceneToChangeTo = SceneToChangeTo;
        initUISettingsScreen.initialiseElements = false;
        startAnim = true;

        PlayerPrefs.SetInt("renderHelp?", 1);

        if (SceneToChangeTo == "OptionScreen_Control")
        {
            targetSquare = GameObject.Find("TopBtn").GetComponent<CanvasGroup>();
            Debug.Log("Start UI Fadeout animation to CTRL Screen");
        }
        else if (SceneToChangeTo == "OptionScreen_Sound")
        {
            targetSquare = GameObject.Find("BottomBtn").GetComponent<CanvasGroup>();
            Debug.Log("Start UI Fadeout animation to SFX Screen");
        }
        else if (SceneToChangeTo == "MenuScreen")
        {
            targetSquare = null;

            settingsText = GameObject.Find("Settings").GetComponent<RectTransform>();
            topBox = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();
            btmBox = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
            settingsSquare = GameObject.Find("Settings Pages").GetComponent<CanvasGroup>();
            backBtn = GameObject.Find("Back Button").GetComponent<CanvasGroup>();

            Debug.Log("Start CTRL fadeout animation to Menu Screen");
        }
    }
}
