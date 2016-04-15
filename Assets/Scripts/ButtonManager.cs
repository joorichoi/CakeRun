using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public static ButtonManager Instance {get; private set; }
    
    private int characterNumber;
    // Use this for initialization
	void Awake() {
	
        Instance = this;
        characterNumber = 0;
        this.transform.GetChild(characterNumber).gameObject.SetActive(true);
	}


    public void GoToInGame()
    {
        SceneManager.LoadScene("InGame_Map01");
    }

    public void ClickLeftCharacterChosen()
    {
        if(characterNumber>0)
        {
            transform.GetChild(characterNumber).gameObject.SetActive(false);
            characterNumber--;
            transform.GetChild(characterNumber).gameObject.SetActive(true);
        }
    }

    public void ClickRightCharacterChosen()
    {
        if(characterNumber<2)
        {
            transform.GetChild(characterNumber).gameObject.SetActive(false);
            characterNumber++;
            transform.GetChild(characterNumber).gameObject.SetActive(true);
        }
    }

}
