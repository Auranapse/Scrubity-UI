using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fading : MonoBehaviour {
    
    Image Entity;
    Color Fader;

    float Timer;

    public float TimeToStartFade;
    public float FadeIntensity;

    public bool isFadeIn;
    public bool isFadeOut;
    
    // Use this for initialization
    void Start()
    {
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
        Timer += Time.deltaTime;
        if (Timer > TimeToStartFade)
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
        Mathf.Clamp01(Fader.a);
        Entity.color = Fader;
    }

    void FadeOut()
    {
        Fader.a -= FadeIntensity;
        Mathf.Clamp01(Fader.a);
        Entity.color = Fader;
    }
}
