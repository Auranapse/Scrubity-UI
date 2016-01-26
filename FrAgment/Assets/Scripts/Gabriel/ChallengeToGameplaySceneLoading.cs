using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ChallengeToGameplaySceneLoading : MonoBehaviour, IPointerClickHandler
{
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
    void Start()
    {
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
    void Update()
    {
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
            translate3.y = Mathf.Lerp(translate3.y, 1000, Time.deltaTime * 10);
            levelGroup.localPosition = translate3;

            if (translate3.y > 700 && translate.x < -950)
            {
                startMenuAnim = true;
            }
        }
        if (startMenuAnim)
        {
            // Rotate top black box
            Vector3 move = topBox.position;
            move.y = move.y + (Time.deltaTime * 450);
            if (move.y > 1000)
            {
                move.y = 1000;
            }
            else
            {
                topBox.position = move;
            }

            // Rotate bottom black box
            Vector3 move2 = btmBox.position;
            move2.y = move2.y - (Time.deltaTime * 300);

            if (move2.y < -980)
            {
                move2.y = -980;
            }
            else
            {
                btmBox.position = move2;
            }

            if (move.y == 1000 && move2.y == -980)
            {
                Application.LoadLevel(SceneToChangeTo);
                Debug.Log("Loading Game");
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!startAnim)
        {
            tracker.SceneToChangeTo = SceneToChangeTo;
            initCHLGScreen.initialiseElements = false;
            startAnim = true;
        }
    }
}
