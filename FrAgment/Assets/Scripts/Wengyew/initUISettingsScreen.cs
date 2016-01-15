using UnityEngine;
using System.Collections;

public class initUISettingsScreen : MonoBehaviour {
    public bool finishedAnim;
    public static bool initialiseElements;

    private RectTransform optionsContainer;
    private CanvasRenderer UIBox;

    // Use this for initialization
    void Start()
    {
        finishedAnim = false;
        initialiseElements = true;

        optionsContainer = GameObject.Find("UI Color Options").GetComponent<RectTransform>();
        UIBox = GameObject.Find("UIBox").GetComponent<CanvasRenderer>();

        UIBox.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedAnim && initialiseElements)
        {
            // Get options into correct position
            Vector3 translate = optionsContainer.localPosition;
            translate.y = Mathf.Lerp(translate.y, 0, Time.deltaTime * 6);
            optionsContainer.localPosition = translate;

            //Make UI box opaque
            UIBox.SetAlpha(Mathf.Lerp(UIBox.GetAlpha(), 1, Time.deltaTime * 10));

            if (optionsContainer.localPosition.y > -1 && UIBox.GetAlpha() == 1)
            {
                finishedAnim = true;
                Debug.Log("Finished UI Settings Init");
            }
        }
    }
}
