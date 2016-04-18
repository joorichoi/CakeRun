using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] private Text           coin_text;
    [SerializeField] private Text           score_text;
    [SerializeField] private Character[]   character_pre;
    
    
    private Character myCharacter;
    private int     my_score;
    private int     my_coin;
    private int     score;

    // Use this for initialization
	void Awake ()
    {
        my_score    = 0;
        my_coin     = 0;
        score       = 0;
	    Instance    = this;
        CreateMyCharacter();

	}


    void CreateMyCharacter()
    {
        myCharacter = Instantiate(character_pre[CharacterSelect.charcterNumber]) as Character;
        myCharacter.name = "MyCharacter";
    }
    void Change_Coin_text()
    {
        coin_text.text = string.Concat("X ", my_coin.ToString());
    }

    void Change_Score_text()
    {
        score_text.text = string.Concat("Score: ",my_score.ToString());
    }
    
    public void BackToMenu()
    {
       SceneManager.LoadScene("Before_InGame");
    }
    public void Get_My_Score(int num)
    {
        score = num * 500;
        my_score += score;
        Change_Score_text();
        score = 0;
    }

    public void Get_My_Coin(int coin)
    {
        my_coin += coin;
        Change_Coin_text();
    }

    public int Set_Score
    {
        get { return my_score;}
        set { my_score = value;}
    }

}
