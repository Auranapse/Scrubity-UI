using UnityEngine;
using System.Collections;

public class initCHLGScreen : MonoBehaviour {
    public bool finishedAnim;
    public static bool initialiseElements;

    private CanvasGroup backBtn;
    private CanvasGroup tintGroup;
    private CanvasGroup leftArrow;
    private CanvasGroup rightArrow;

    private RectTransform levelGroup;
    private RectTransform heartGroup;

    private RectTransform challengesText;

    // Use this for initialization
    void Start()
    {
        finishedAnim = false;
        initialiseElements = true;

        backBtn = GameObject.Find("Back Button").GetComponent<CanvasGroup>();
        tintGroup = GameObject.Find("Tint Group").GetComponent<CanvasGroup>();
        leftArrow = GameObject.Find("LeftArrow").GetComponent<CanvasGroup>();
        rightArrow = GameObject.Find("RightArrow").GetComponent<CanvasGroup>();

        levelGroup = GameObject.Find("Levels").GetComponent<RectTransform>();
        heartGroup = GameObject.Find("Hearts").GetComponent<RectTransform>();
        challengesText = GameObject.Find("Challenges").GetComponent<RectTransform>();

        Vector3 translate = levelGroup.localPosition;
        translate.x = (UpdateCHLGScreen.challengePage - 1) * -850;
        levelGroup.localPosition = translate;

        backBtn.alpha = 0;
        tintGroup.alpha = 0;
        leftArrow.alpha = 0;
        rightArrow.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedAnim && initialiseElements)
        {
            //Get challenges title into correct position
            Vector3 translate = challengesText.localPosition;
            translate.x = Mathf.Lerp(translate.x, -184, Time.deltaTime * 5);
            challengesText.localPosition = translate;

            //Get heart group into correct position
            Vector3 translate2 = heartGroup.localPosition;
            translate2.y = Mathf.Lerp(translate2.y, 0, Time.deltaTime * 5);
            heartGroup.localPosition = translate2;

            //Get level group into correct position
            Vector3 translate3 = levelGroup.localPosition;
            translate3.y = Mathf.Lerp(translate3.y, -4, Time.deltaTime * 5);
            levelGroup.localPosition = translate3;

            //Make arrows/backbutton/tintgroup opaque
            backBtn.alpha = Mathf.Lerp(backBtn.alpha, 0.5f, Time.deltaTime * 3);
            tintGroup.alpha = Mathf.Lerp(tintGroup.alpha, 1, Time.deltaTime * 8);
            leftArrow.alpha = Mathf.Lerp(leftArrow.alpha, 0.5f, Time.deltaTime * 3);
            rightArrow.alpha = Mathf.Lerp(rightArrow.alpha, 0.5f, Time.deltaTime * 3);

            //if (true)
            //{
            //    finishedAnim = true;
            //    AllowClickInput.canClick = true;
            //    Debug.Log("Finished CHLG Init");
            //}
        }
    }
}
