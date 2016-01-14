using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CHLGFadeout : MonoBehaviour, IPointerClickHandler {
    public string SceneToChangeTo;

    private bool startAnim;
    private bool startMenuAnim;

    private CanvasGroup backBtn;
    private CanvasGroup tintGroup;
    private CanvasGroup rightArrow;

    private RectTransform levelGroup;
    private RectTransform heartGroup;

    private RectTransform topBox;
    private RectTransform btmBox;
    private RectTransform challengesText;    

	// Use this for initialization
	void Start () {
        startMenuAnim = false;
        startAnim = false;

        backBtn = GameObject.Find("Back Button").GetComponent<CanvasGroup>();
        tintGroup = GameObject.Find("Tint Group").GetComponent<CanvasGroup>();
        rightArrow = GameObject.Find("RightArrow").GetComponent<CanvasGroup>();

        levelGroup = GameObject.Find("Levels").GetComponent<RectTransform>();
        heartGroup = GameObject.Find("Hearts").GetComponent<RectTransform>();
        challengesText = GameObject.Find("Challenges").GetComponent<RectTransform>();

        topBox = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();
        btmBox = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        //Fade out Back btn, Left/Right arrow btns, Tint group
        if (startAnim)
        {
            backBtn.alpha = (Mathf.Lerp(backBtn.alpha, 0.0f, Time.deltaTime * 10));
            tintGroup.alpha = (Mathf.Lerp(tintGroup.alpha, 0.0f, Time.deltaTime * 10));
            rightArrow.alpha = (Mathf.Lerp(rightArrow.alpha, 0.0f, Time.deltaTime * 10));

            //Move challenges out
            Vector3 translate = challengesText.localPosition;
            translate.x = Mathf.Lerp(translate.x, -1000, Time.deltaTime * 13);
            challengesText.localPosition = translate;

            //Move heart icon + text out
            Vector3 translate2 = heartGroup.localPosition;
            translate2.y = Mathf.Lerp(translate2.y, -200, Time.deltaTime * 10);
            heartGroup.localPosition = translate2;

            //Move levelgroups out
            Vector3 translate3 = levelGroup.localPosition;
            translate3.y = Mathf.Lerp(translate3.y, 800, Time.deltaTime * 10);
            levelGroup.localPosition = translate3;

            if (translate3.y > 700 && translate.x < -950) {
                startMenuAnim = true;
            }
        }
        if (startMenuAnim)
        {
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

            if (rotate.z == 343.9929f && rotate2.z == 26.53186f)
            {
                Application.LoadLevel(SceneToChangeTo);
                Debug.Log("Loading Menu");
            }
        }
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!startAnim)
        {
            tracker.SceneToChangeTo = SceneToChangeTo;
            initCHLGScreen.initialiseElements = false;
            AllowClickInput.canClick = false;
            startAnim = true;

            Debug.Log("Start CHLG animation to Menu Screen");
        }
    }
}
