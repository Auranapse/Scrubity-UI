using UnityEngine;
using System.Collections;

public class initSFXSettingsScreen : MonoBehaviour {
    public bool finishedAnim;
    public static bool initialiseElements;

    private RectTransform optionsContainer;
    private CanvasGroup SoundTypeGroup;

    private CanvasGroup pianoIcon;
    private CanvasGroup eightbitIcon;
    private CanvasGroup metalIcon;

    // Use this for initialization
    void Start()
    {
        finishedAnim = false;
        initialiseElements = true;

        optionsContainer = GameObject.Find("Volume Options").GetComponent<RectTransform>();
        SoundTypeGroup = GameObject.Find("Sound Type Buttons").GetComponent<CanvasGroup>();

        SoundTypeGroup.alpha = 0;

        pianoIcon = GameObject.Find("Piano_icon").GetComponent<CanvasGroup>();
        eightbitIcon = GameObject.Find("8bit_icon").GetComponent<CanvasGroup>();
        metalIcon = GameObject.Find("metal_icon").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
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
                Debug.Log("Finished SFX Settings Init");
            }
        }
    }

    public void setMusicTypePiano()
    {
        PlayerPrefs.SetInt("MusicType", 1);
    }

    public void setMusicType8bit()
    {
        PlayerPrefs.SetInt("MusicType", 2);

        MusicManager.sfx[0] = (AudioClip)Resources.Load("8bit_menu_bgm");
        MusicManager.sfx[1] = (AudioClip)Resources.Load("8bit_battle_bgm");
        MusicManager.sfx[2] = (AudioClip)Resources.Load("8bit_button_press");
        MusicManager.sfx[3] = (AudioClip)Resources.Load("8bit_sound_select");
        MusicManager.sfx[4] = (AudioClip)Resources.Load("8bit_swipe");
        MusicManager.sfx[5] = (AudioClip)Resources.Load("8bit_control_select");
        MusicManager.sfx[6] = (AudioClip)Resources.Load("8bit_options_change");

        MusicManager.BGM_Player.clip = MusicManager.sfx[0];
        MusicManager.BGM_Player.Play();
    }

    public void setMusicTypeMetal()
    {
        PlayerPrefs.SetInt("MusicType", 3);
    }
}
