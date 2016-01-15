using UnityEngine;
using System.Collections;

public class EditKeyBy1UsingButtons : MonoBehaviour {

    public string KeyAffected;

    public int keyLowerLimit;
    public int keyUpperLimit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void decreaseKey()
    {
        PlayerPrefs.SetInt(KeyAffected, Mathf.Max(keyLowerLimit, PlayerPrefs.GetInt(KeyAffected) - 1));
    }

    public void IncreaseKey()
    {
        PlayerPrefs.SetInt(KeyAffected, Mathf.Min(keyUpperLimit, PlayerPrefs.GetInt(KeyAffected) + 1));
    }
}
