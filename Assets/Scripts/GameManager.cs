using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] private Text           coin_text;
    [SerializeField] private Text           score_text;
    [SerializeField] private Text           resultCoinText;
    [SerializeField] private Text           resultScoreText;
    [SerializeField] private Character[]    character_pre;
    [SerializeField] private Image[]        rankImage;          
    
    
    private Character myCharacter;
    private int     my_score;
    private int     my_coin;
    private int     coinScore;
    private int     score;

    private int     finalScore;

    // Use this for initialization
	void Awake ()
    {
        my_score    = 0;
        my_coin     = 0;
        coinScore   = 0;
        score       = 0;
	    Instance    = this;
        CreateMyCharacter();
        for(int i=0;i<rankImage.Length;i++)
        {
            rankImage[i].gameObject.SetActive(false);
        }

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

    private void ChangeResultScore()
    {
        resultScoreText.text = string.Concat(my_score.ToString());
        resultCoinText.text  = string.Concat(coinScore.ToString());
        finalScore = my_score +coinScore;
    }

    private void ChangeResultRank()
    {
        if(finalScore<=20000)
        {
            //F
            rankImage[0].gameObject.SetActive(true);
        }
        else if(finalScore <= 50000)
        {
            //A
            rankImage[1].gameObject.SetActive(true);
        }
        else if(finalScore <= 75000)
        {
            //S
            rankImage[2].gameObject.SetActive(true);
        }
        else if(finalScore <= 100000)
        {
            //SS
            rankImage[3].gameObject.SetActive(true);
        }
        else
        {
            rankImage[4].gameObject.SetActive(true);
        }
    }
    public void Get_My_Coin(int coin)
    {
        my_coin += coin;
        Change_Coin_text();
    }

    private void My_Coin_Score()
    {
        coinScore = my_coin * 100;
    }


    public void ChangeResult()
    {
        My_Coin_Score();
        ChangeResultScore();
        ChangeResultRank();
    }
    public int Set_Score
    {
        get { return my_score;}
        set { my_score = value;}
    }

}
