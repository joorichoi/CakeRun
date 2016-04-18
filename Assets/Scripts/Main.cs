using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
        Invoke("GoToInGameScene",2.0f);
	}

    void GoToInGameScene()
    {
        SceneManager.LoadScene("Before_InGame");
    }
}
