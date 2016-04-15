using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public static ButtonManager Instance {get; private set; }
	// Use this for initialization
	void Awake() {
	
        Instance = this;
	}


    public void GoToInGame()
    {
        SceneManager.LoadScene("InGame_Map01");
    }

}
