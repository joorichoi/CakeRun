using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    private enum Character_State { RUN=0, JUMP, DOUBLEJUMP, ROAP }

    private Character_State character_state;
    private Transform       my_transform; 
    private Rigidbody2D     my_rig;


	// Use this for initialization
	void Awake () {
	    character_state = Character_State.RUN;
        my_transform = GetComponent<Transform>();
        my_rig = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    private void State_Change()
    {
        if(Input.GetMouseButtonDown(1) && character_state==Character_State.RUN)
        {

        }
    }


    private void Jump()
    {
        my_rig.AddForce(Vector2.up * 400);
    }

}
