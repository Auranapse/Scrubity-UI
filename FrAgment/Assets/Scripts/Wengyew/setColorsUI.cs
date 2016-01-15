using UnityEngine;
using System.Collections;

public class setColorsUI : MonoBehaviour {

    private static setColorsUI instance = null;

    public static setColorsUI Instance
    {
        get { return instance; }
    }

    public static bool UpdateColor;
    public static Color UIColor;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("UI_Rv"))
        {
            PlayerPrefs.SetInt("UI_Rv", 255);
            PlayerPrefs.SetInt("UI_Gv", 176);
            PlayerPrefs.SetInt("UI_Bv", 76);
            PlayerPrefs.SetInt("UI_Av", 255);
        }

        UIColor = new Color();

        UIColor.r = PlayerPrefs.GetInt("UI_Rv") / 255.0f;
        UIColor.g = PlayerPrefs.GetInt("UI_Gv") / 255.0f;
        UIColor.b = PlayerPrefs.GetInt("UI_Bv") / 255.0f;
        UIColor.a = 255;
	}
	
	// Update is called once per frame
	void Update () {
	    if (UpdateColor)
        {
            UpdateColor = false;

            UIColor.r = PlayerPrefs.GetInt("UI_Rv") / 255.0f;
            UIColor.g = PlayerPrefs.GetInt("UI_Gv") / 255.0f;
            UIColor.b = PlayerPrefs.GetInt("UI_Bv") / 255.0f;
        }
	}
}
