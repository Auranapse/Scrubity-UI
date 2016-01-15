using UnityEngine;
using System.Collections;

public class playSFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void SFXPlayButtonPressMethod()
    {
        MusicManager.SFX_Player.clip = MusicManager.sfx[(int)MusicManager.SoundList.button_press];
        MusicManager.SFX_Player.Play();
    }

    public void SFXPlayButtonPress()
    {
        MusicManager.SFX_Player.clip = MusicManager.sfx[(int)MusicManager.SoundList.button_press];
        MusicManager.SFX_Player.Play();
    }

    public static void SFXPlaySwipe()
    {
        MusicManager.SFX_Player.clip = MusicManager.sfx[(int)MusicManager.SoundList.sound_swipe];
        MusicManager.SFX_Player.Play();
    }

    public void SFXPlaySoundSelect()
    {
        MusicManager.SFX_Player.clip = MusicManager.sfx[(int)MusicManager.SoundList.sound_select];
        MusicManager.SFX_Player.Play();
    }

    public void SFXPlayControlSelect()
    {
        MusicManager.SFX_Player.clip = MusicManager.sfx[(int)MusicManager.SoundList.control_select];
        MusicManager.SFX_Player.Play();
    }

    public void SFXPlayOptionsChange()
    {
        MusicManager.SFX_Player.clip = MusicManager.sfx[(int)MusicManager.SoundList.options_change];
        MusicManager.SFX_Player.Play();
    }
}
