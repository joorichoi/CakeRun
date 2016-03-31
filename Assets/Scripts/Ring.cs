using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

    private bool is_ringenter;
    private Transform my_transform;

	// Use this for initialization
	void Awake() {
	    my_transform = GetComponent<Transform>();
        is_ringenter = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Decide_Score()
    {
        if(is_ringenter)
            Debug.Log("True");
    }
    
    public bool Get_RingEnter{
        set { is_ringenter = value; }
        get { return is_ringenter;}
    }
}
