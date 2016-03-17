using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {

    private static GroundManager instance;
    public static GroundManager Instance { get { return instance;} }
	
    [SerializeField] private float speed;
    private float move_pos;

    // Use this for initialization

	void Awake ()
    {
	    instance = this;
        move_pos = .0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    move_pos = speed * Time.smoothDeltaTime;
        transform.Translate(Vector2.left * move_pos);

	}
}
