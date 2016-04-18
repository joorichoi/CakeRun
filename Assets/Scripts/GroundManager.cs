using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {

    public static GroundManager Instance { get; private set;}
	
    [SerializeField] private float speed;
    private float   move_pos;
    private bool    is_move;

    // Use this for initialization

	void Awake ()
    {
	    Instance = this;
        move_pos = .0f;
        is_move = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(is_move)
	        Move_Ground();

        if(transform.position.x<=-260.0f)
        {
            is_move = false;
            GameObject.Find("Canvas").transform.FindChild("Result").gameObject.SetActive(true);
            GameManager.Instance.ChangeResult();
        }
	}


    void Move_Ground()
    {
        move_pos = speed * Time.smoothDeltaTime;
        transform.Translate(Vector2.left * move_pos);
    }


    public bool Set_Move{
        get { return is_move; }
        set { is_move = value;}
    }
}
