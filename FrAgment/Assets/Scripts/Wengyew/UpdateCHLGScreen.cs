using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateCHLGScreen : MonoBehaviour {

    public static int challengePage;
    public static bool updateStuff;

    private GameObject leftArrow;
    private GameObject rightArrow;

    private CanvasRenderer[] tintBox;

    public bool changePageAnim;

	// Use this for initialization
	void Start () {
        leftArrow = GameObject.Find("LeftArrow");
        rightArrow = GameObject.Find("RightArrow");

        tintBox = new CanvasRenderer[3];

        tintBox[0] = GameObject.Find("tint_page1").GetComponent<CanvasRenderer>();
        tintBox[1] = GameObject.Find("tint_page2").GetComponent<CanvasRenderer>();
        tintBox[2] = GameObject.Find("tint_page3").GetComponent<CanvasRenderer>();

        challengePage = 1;
        updateStuff = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (updateStuff)
        {
            updateStuff = false;
            if (challengePage < 1)
                challengePage = 1;
            if (challengePage > 3)
                challengePage = 3;

            for (int i = 0; i < 3; i++)
            {
                if (i == challengePage-1)
                {
                    tintBox[i].SetAlpha(1);
                }
                else
                {
                    tintBox[i].SetAlpha(0.3f);
                }
            }

            if (challengePage == 1)
            {
                //Disable left button
                CanvasRenderer disableRender = leftArrow.GetComponent<CanvasRenderer>();
                disableRender.SetAlpha(0);

                Button disableBtn = leftArrow.GetComponent<Button>();
                disableBtn.interactable = false;

                //Enable right arrow
                CanvasRenderer enableRender = rightArrow.GetComponent<CanvasRenderer>();
                enableRender.SetAlpha(0.5f);

                Button enableBtn = rightArrow.GetComponent<Button>();
                enableBtn.interactable = true;
            }
            else if (challengePage == 3)
            {
                //Enable left arrow
                CanvasRenderer disableRender = leftArrow.GetComponent<CanvasRenderer>();
                disableRender.SetAlpha(0.5f);

                Button disableBtn = leftArrow.GetComponent<Button>();
                disableBtn.interactable = true;

                //Disable right arrow
                CanvasRenderer enableRender = rightArrow.GetComponent<CanvasRenderer>();
                enableRender.SetAlpha(0);

                Button enableBtn = rightArrow.GetComponent<Button>();
                enableBtn.interactable = true;
            }
            else
            {
                //Enable right arrow
                CanvasRenderer enableRender = rightArrow.GetComponent<CanvasRenderer>();
                enableRender.SetAlpha(0.5f);

                Button enableBtn = rightArrow.GetComponent<Button>();
                enableBtn.interactable = true;

                //Enable left arrow
                enableRender = rightArrow.GetComponent<CanvasRenderer>();
                enableRender.SetAlpha(0.5f);

                enableBtn = rightArrow.GetComponent<Button>();
                enableBtn.interactable = true;
            }
        }
        if (changePageAnim)
        {

        }
	}
}
