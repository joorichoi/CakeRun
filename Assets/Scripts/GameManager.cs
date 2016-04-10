using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    private int   my_score;
    private int   my_coin;

    // Use this for initialization
	void Awake ()
    {
        my_score = 0;
        my_coin = 0;
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public int Set_Score
    {
        get { return my_score;}
        set { my_score = value;}
    }

    public int Set_Coin
    {
        get { return my_coin;}
        set { my_coin = value;}
    }
}
