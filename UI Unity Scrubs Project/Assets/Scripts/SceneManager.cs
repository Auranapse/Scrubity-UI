using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public SceneLoader LoadSceneScript;
    public float TimeToChangeScene;

    float Timer;
  
	// Use this for initialization
	void Start () {
        Timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (Timer > TimeToChangeScene)
        {
            LoadSceneScript.doLoad = true;
        }
	}
}
