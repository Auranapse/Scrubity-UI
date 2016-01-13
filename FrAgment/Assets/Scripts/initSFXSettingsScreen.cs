using UnityEngine;
using System.Collections;

public class initSFXSettingsScreen : MonoBehaviour {
    public bool finishedAnim;
    public static bool initialiseElements;

    private RectTransform optionsContainer;
    private CanvasGroup SoundTypeGroup;

    // Use this for initialization
    void Start()
    {
        AllowClickInput.canClick = false;
        finishedAnim = false;
        initialiseElements = true;

        optionsContainer = GameObject.Find("Volume Options").GetComponent<RectTransform>();
        SoundTypeGroup = GameObject.Find("Sound Type Buttons").GetComponent<CanvasGroup>();

        SoundTypeGroup.alpha = 0;
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
            SoundTypeGroup.alpha = Mathf.Lerp(SoundTypeGroup.alpha, 1, Time.deltaTime * 4);

            if (optionsContainer.localPosition.y > -1 && SoundTypeGroup.alpha > 0.9f)
            {
                finishedAnim = true;
                AllowClickInput.canClick = true;
                Debug.Log("Finished SFX Settings Init");
            }
        }
    }
}
