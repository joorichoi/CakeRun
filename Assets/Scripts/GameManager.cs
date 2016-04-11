using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] private Text coin_text;
    [SerializeField] private Text score_text;
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
	}

    void Change_Coin_text()
    {
        coin_text.text = my_coin.ToString();
    }
    void Change_Score_text()
    {
        score_text.text = my_score.ToString();
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
