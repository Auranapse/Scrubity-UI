using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fading : MonoBehaviour {
    
    Image Entity;
    public Color Fader;

    public float TimeToStartFade;
    public float FadeIntensity;

    public bool isFadeIn;
    public bool isFadeOut;
    public bool isComplete;

    // Use this for initialization
    void Start()
    {
        isComplete = false;
        Entity = GetComponent<Image>();
        Fader = Entity.color;
        if (isFadeIn == true)
        {
            Fader.a = 0;
        }
        if (isFadeOut == true)
        {
            Fader.a = 1;
        }

        Entity.color = Fader;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.unscaledTime > TimeToStartFade)
        {
            if (isFadeIn == true)
            {
                FadeIn();
            }
            if (isFadeOut == true)
            {
                FadeOut();
            }
        }
	}

    void FadeIn()
    {
        Fader.a += FadeIntensity;
        Entity.color = Fader;

        if (Fader.a > 1)
        {
            Fader.a = 1;
            isComplete = true;
        }
    }

    void FadeOut()
    {
        Fader.a -= FadeIntensity;
        Entity.color = Fader;

        if (Fader.a < 0)
        {

            Fader.a = 0;
            isComplete = true;
        }
    }
}
