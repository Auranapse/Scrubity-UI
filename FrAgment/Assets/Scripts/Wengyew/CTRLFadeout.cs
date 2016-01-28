using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CTRLFadeout : MonoBehaviour
{
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
    void Start()
    {
        startAnim = false;
        startMenuAnim = false;

        optionsContainer = GameObject.Find("Options").GetComponent<RectTransform>();
        spaceship = GameObject.Find("Spaceship").GetComponent<RectTransform>();

        curSquare = GameObject.Find("TopBtn").GetComponent<CanvasRenderer>();

        wtfUnityFloats = false;
        annoying = false;
    }

    Vector3 topR, botR;
    Vector3 stupidUnity;
    bool wtfUnityFloats, annoying;
    // Update is called once per frame
    void Update()
    {
        if (startAnim)
        {
            GameObject.Find("Options Tutorial").GetComponent<CanvasGroup>().alpha = 0;

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
            //Remove spaceship from view
            spaceship.localScale = Vector3.zero;

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
        initCTRLSettingsScreen.initialiseElements = false;
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
