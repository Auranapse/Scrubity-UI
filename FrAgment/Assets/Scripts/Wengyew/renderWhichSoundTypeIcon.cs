using UnityEngine;
using System.Collections;

public class renderWhichSoundTypeIcon : MonoBehaviour {

    private CanvasGroup pianoIcon;
    private CanvasGroup eightbitIcon;
    private CanvasGroup metalIcon;

	// Use this for initialization
	void Start () {
        pianoIcon = GameObject.Find("Piano_icon").GetComponent<CanvasGroup>();
        eightbitIcon = GameObject.Find("8bit_icon").GetComponent<CanvasGroup>();
        metalIcon = GameObject.Find("metal_icon").GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("MusicType") == 1)
        {
            pianoIcon.alpha = (Mathf.Lerp(pianoIcon.alpha, 0.3f, Time.deltaTime * 3));
            eightbitIcon.alpha = (Mathf.Lerp(eightbitIcon.alpha, 0.0f, Time.deltaTime * 3));
            metalIcon.alpha = (Mathf.Lerp(metalIcon.alpha, 0.0f, Time.deltaTime * 3));
        }
        else if (PlayerPrefs.GetInt("MusicType") == 2)
        {
            pianoIcon.alpha = (Mathf.Lerp(pianoIcon.alpha, 0.0f, Time.deltaTime * 3));
            eightbitIcon.alpha = (Mathf.Lerp(eightbitIcon.alpha, 0.3f, Time.deltaTime * 3));
            metalIcon.alpha = (Mathf.Lerp(metalIcon.alpha, 0.0f, Time.deltaTime * 3));
        }
        else if (PlayerPrefs.GetInt("MusicType") == 3)
        {
            pianoIcon.alpha = (Mathf.Lerp(pianoIcon.alpha, 0.0f, Time.deltaTime * 3));
            eightbitIcon.alpha = (Mathf.Lerp(eightbitIcon.alpha, 0.0f, Time.deltaTime * 3));
            metalIcon.alpha = (Mathf.Lerp(metalIcon.alpha, 0.3f, Time.deltaTime * 3));
        }
	}

    public void setMusicTypePiano()
    {
        PlayerPrefs.SetInt("MusicType", 1);
    }

    public void setMusicType8bit()
    {
        PlayerPrefs.SetInt("MusicType", 2);
    }

    public void setMusicTypeMetal()
    {
        PlayerPrefs.SetInt("MusicType", 3);
    }
}
