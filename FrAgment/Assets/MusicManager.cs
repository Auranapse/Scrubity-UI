using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    private static MusicManager instance = null;

    public static MusicManager Instance
    {
        get { return instance; }
    }

    private AudioSource[] sounds;
    public static AudioClip[] sfx;

    public static AudioSource BGM_Player;
    public static AudioSource SFX_Player;
    public static AudioSource SFX2_Player;

    public enum SoundList
    {
        menu_bgm = 0,
        battle_bgm = 1,

        button_press = 2,
        sound_select = 3,
        sound_swipe = 4,
        control_select = 5,
        options_change = 6,

        soundlist_totalsounds
    };

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        sounds = GetComponents<AudioSource>();
        BGM_Player = sounds[0];
        SFX_Player = sounds[1];
        SFX2_Player = sounds[2];

        sfx = new AudioClip[(int)SoundList.soundlist_totalsounds];
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("MusicType") == 1) //piano
        {
        }
        else if (PlayerPrefs.GetInt("MusicType") == 2) //8bit
        {
            sfx[0] = (AudioClip)Resources.Load("8bit_menu_bgm");
            sfx[1] = (AudioClip)Resources.Load("8bit_battle_bgm");
            sfx[2] = (AudioClip)Resources.Load("8bit_button_press");
            sfx[3] = (AudioClip)Resources.Load("8bit_sound_select");
            sfx[4] = (AudioClip)Resources.Load("8bit_swipe");
            sfx[5] = (AudioClip)Resources.Load("8bit_control_select");
            sfx[6] = (AudioClip)Resources.Load("8bit_options_change");
        }
        else if (PlayerPrefs.GetInt("MusicType") == 3) // metal
        {

        }

        BGM_Player.clip = sfx[0];
        BGM_Player.Play();
    }

    void Update()
    {
        BGM_Player.volume = (float)(PlayerPrefs.GetInt("MusicVolume")) * 0.01f;
        SFX_Player.volume = (float)(PlayerPrefs.GetInt("SoundVolume")) * 0.01f;
        SFX2_Player.volume = (float)(PlayerPrefs.GetInt("SoundVolume")) * 0.01f;
    }
}