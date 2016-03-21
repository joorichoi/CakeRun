using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    private enum Character_State { RUN=0, JUMP, DOUBLEJUMP, ROAP }

    private Character_State character_state;
    private Transform       my_transform; 
    private Rigidbody2D     my_rig;
    private Animator        my_animator;
    private bool            grounded;

    [SerializeField]private Transform check_ground;
    [SerializeField]private LayerMask ground;

	// Use this for initialization
	void Awake () {
	    character_state = Character_State.RUN;
        my_transform = GetComponent<Transform>();
        my_rig = GetComponent<Rigidbody2D>();
        my_animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
	    grounded =Physics2D.OverlapCircle(check_ground.position, 0.1f, 1 << LayerMask.NameToLayer("Ground"));

        if(grounded)
        {
            my_animator.SetBool("is_jump",false);
        }
        if(Input.GetKeyDown(KeyCode.Space)&&grounded)
            Jump();
        if(Input.GetKeyDown(KeyCode.Space)&&!grounded)
        {
            Jump();
        }
	}


    private void Jump()
    {
        my_rig.AddForce(Vector2.up * 400);
        my_animator.SetBool("is_jump", true);
    }

}
