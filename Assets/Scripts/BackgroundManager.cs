using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

    private static BackgroundManager instance;
    public static BackgroundManager Instance { get { return instance; } }

    [SerializeField] private Background[]   background;
    [SerializeField] private float          speed;
    private float                           move_pos;
    private float                           move_dis;

	// Use this for initialization
	void Awake ()
    {
        instance = this;
        move_pos = .0f;
        move_dis = .0f;

        for(int i=0; i<2;++i)
        {
            background[i].Init();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    move_pos = speed * Time.smoothDeltaTime;

        for(int i=0;i<2;++i)
        {
            background[i].Updated(move_pos);
        }

        move_dis += move_pos;
	}
}
