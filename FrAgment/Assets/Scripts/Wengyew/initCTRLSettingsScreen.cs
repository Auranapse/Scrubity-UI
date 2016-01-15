using UnityEngine;
using System.Collections;

public class initCTRLSettingsScreen : MonoBehaviour {
    public bool finishedAnim;
    public static bool initialiseElements;

    private RectTransform optionsContainer;
    private RectTransform spaceship;

    private CanvasRenderer optionsHelp;

    // Use this for initialization
    void Start()
    {
        finishedAnim = false;
        initialiseElements = true;

        optionsContainer = GameObject.Find("Options").GetComponent<RectTransform>();
        spaceship = GameObject.Find("Spaceship").GetComponent<RectTransform>();

        optionsHelp = GameObject.Find("Options Tutorial").GetComponent<CanvasRenderer>();
        optionsHelp.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedAnim && initialiseElements)
        {
            // Get options into correct position
            Vector3 translate = optionsContainer.localPosition;
            translate.y = Mathf.Lerp(translate.y, 2, Time.deltaTime * 8);
            optionsContainer.localPosition = translate;

            //Get spaceship into middle
            translate = spaceship.localPosition;
            translate.y = Mathf.Lerp(translate.y, -50, Time.deltaTime * 6);
            spaceship.localPosition = translate;
            
            //Make tutorial text opaque
            optionsHelp.SetAlpha(Mathf.Lerp(optionsHelp.GetAlpha(), 1, Time.deltaTime * 3));

            if (optionsContainer.localPosition.y > -2 && spaceship.localPosition.y < -36)
            {
                finishedAnim = true;
                Debug.Log("Finished CTRL Settings Init");
            }
        }
    }
}
