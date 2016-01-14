using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CTRLFadeout : MonoBehaviour {
    public string SceneToChangeTo;

    private bool startAnim;
    private bool startMenuAnim;

    private RectTransform optionsContainer;
    private RectTransform spaceship;

    private CanvasRenderer curSquare;
    private CanvasGroup targetSquare;

    private RectTransform settingsText;
    private RectTransform topBox;
    private RectTransform btmBox;

    private CanvasGroup settingsSquare;
    private CanvasGroup backBtn;

	// Use this for initialization
	void Start () {
        AllowClickInput.canClick = true;
        startAnim = false;
        startMenuAnim = false;

        optionsContainer = GameObject.Find("Options").GetComponent<RectTransform>();
        spaceship = GameObject.Find("Spaceship").GetComponent<RectTransform>();

        curSquare = GameObject.Find("TopBtn").GetComponent<CanvasRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (startAnim)
        {
            // Get options out of the way
            Vector3 translate = optionsContainer.localPosition;
            translate.y = Mathf.Lerp(translate.y, -460, Time.deltaTime * 10);
            optionsContainer.localPosition = translate;

            //Transition square opacity
            curSquare.SetAlpha(Mathf.Lerp(curSquare.GetAlpha(), 0.3f, Time.deltaTime * 12));
            if (targetSquare != null)
                targetSquare.alpha = (Mathf.Lerp(targetSquare.alpha, 1.0f, Time.deltaTime * 10));

            //Get spaceship out of the way
            translate = spaceship.localPosition;
            translate.y = Mathf.Lerp(translate.y, 700, Time.deltaTime * 10);
            spaceship.localPosition = translate;

            if (optionsContainer.localPosition.y < -260 && spaceship.localPosition.y > 500)
            {
                startAnim = false;
                if (SceneToChangeTo == "MenuScreen") {
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
            //Remove spaceship from view
            spaceship.localScale = Vector3.zero;

            //Move settings out
            Vector3 translate = settingsText.localPosition;
            translate.x = Mathf.Lerp(translate.x, -900, Time.deltaTime * 10);
            settingsText.localPosition = translate;

            // Rotate top black box
            Vector3 rotate = topBox.localEulerAngles;
            rotate.z = rotate.z - (Time.deltaTime * 140);
            if (rotate.z < 20) rotate.z += 360;
            if (rotate.z < 343.9929f) {
                rotate.z = 343.9929f;
            } else {
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
            else {
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
        initCTRLSettingsScreen.initialiseElements = false;
        AllowClickInput.canClick = false;
        startAnim = true;

        PlayerPrefs.SetInt("renderHelp?", 0);

        if (SceneToChangeTo == "OptionScreen_UI")
        {
            targetSquare = GameObject.Find("MiddleBtn").GetComponent<CanvasGroup>();
            Debug.Log("Start CTRL Fadeout animation to UI Screen");
        }
        else if (SceneToChangeTo == "OptionScreen_Sound")
        {
            targetSquare = GameObject.Find("BottomBtn").GetComponent<CanvasGroup>();
            Debug.Log("Start CTRL Fadeout animation to SFX Screen");
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
