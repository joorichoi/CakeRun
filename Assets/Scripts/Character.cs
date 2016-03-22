﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    private enum Character_State { RUN=0, JUMP, DOUBLEJUMP, ROAP }

    private Character_State character_state;
    private Transform       my_transform; 
    private Rigidbody2D     my_rig;
    private Animator        my_animator;

    private int             jump_count;
    private bool            grounded;
    private bool            is_rideroap;

    [SerializeField]private float     jump_force;
    [SerializeField]private Transform check_ground;
    [SerializeField]private LayerMask ground;

	// Use this for initialization
	void Awake () {
	    character_state = Character_State.RUN;
        my_transform = GetComponent<Transform>();
        my_rig = GetComponent<Rigidbody2D>();
        my_animator = GetComponent<Animator>();
        is_rideroap = false;
        jump_count = 2;
        
	}
	
	// Update is called once per frame
	void Update () {
	    grounded =Physics2D.OverlapCircle(check_ground.position, 0.1f, 1 << LayerMask.NameToLayer("Ground"));

        if(grounded && my_rig.velocity.y <0)
        {
            jump_count = 2;
            character_state = Character_State.RUN;
            my_animator.SetBool("is_jump",false);
        }
	}


    public void Jump()
    {
        if(jump_count>0)
        {
            jump_count--;
            my_rig.AddForce(Vector2.up * jump_force);
            character_state = Character_State.JUMP;
            my_animator.SetBool("is_jump", true);
        }
    }

    private void Ride_roap()
    {
        my_rig.gravityScale = 0.0f;
        my_rig.velocity = Vector2.zero;
        character_state = Character_State.ROAP;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Roap"))
        {
            Ride_roap();
            is_rideroap = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Roap"))
        {
            leave_roap();
        }
    }

    public void leave_roap()
    {
        if(is_rideroap)
        {
            my_rig.gravityScale = 2.5f;
            my_rig.AddForce(Vector2.down * jump_force);
            is_rideroap = false;
        }
    }



}