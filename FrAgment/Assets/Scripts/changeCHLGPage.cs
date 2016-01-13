using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class changeCHLGPage : MonoBehaviour, IPointerClickHandler {

    public int changePageNum;
    public bool incrementPage;
    public bool decrementPage;

    private RectTransform levelGroup;

    // Swiping
    private Vector2 curDownPos;
    private float curDownTime;
    private bool singleMouseInput;

	// Use this for initialization
	void Start () {
        levelGroup = GameObject.Find("Levels").GetComponent<RectTransform>();
        singleMouseInput = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (levelGroup.localPosition.x != (UpdateCHLGScreen.challengePage-1) * -850)
        {
            Vector3 translate = levelGroup.localPosition;
            if (UpdateCHLGScreen.challengePage < 1 || UpdateCHLGScreen.challengePage > 3)
                translate.x = Mathf.Lerp(translate.x, (UpdateCHLGScreen.challengePage - 1) * -850, Time.deltaTime * 0.25f);
            else
                translate.x = Mathf.Lerp(translate.x, (UpdateCHLGScreen.challengePage - 1) * -850, Time.deltaTime * 8);
            levelGroup.localPosition = translate;
        }
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateCHLGScreen.updateStuff = true;
        if (incrementPage)
        {
            UpdateCHLGScreen.challengePage += 1;
        }
        else if (decrementPage)
        {
            UpdateCHLGScreen.challengePage -= 1;
        }
        else
        {
            UpdateCHLGScreen.challengePage = changePageNum;
        }
    }
}
