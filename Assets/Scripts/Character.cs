using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Transform       my_transform; 
    private Rigidbody2D     my_rig;
    private Animator        my_animator;

    private int             jump_count;
    private bool            grounded;
    private bool            is_rideroap;
    private bool            isOnMouseDown;
    private bool            isAlive;

    [SerializeField]private float       jump_force;
    [SerializeField]private Transform   check_ground;
    [SerializeField]private LayerMask   ground;

	// Use this for initialization
	void Awake () {
        my_transform = GetComponent<Transform>();
        my_rig = GetComponent<Rigidbody2D>();
        my_animator = GetComponent<Animator>();
        is_rideroap = false;
        isOnMouseDown = false;
        isAlive = true;
        jump_count = 2;  
	}
	
	// Update is called once per frame
	void Update () {

	    grounded =Physics2D.OverlapCircle(check_ground.position, 0.5f, 1 << LayerMask.NameToLayer("Ground"));

        if(grounded && my_rig.velocity.y < 0)
        {
            jump_count=2;
            my_animator.SetBool("is_jump",false);
            my_animator.SetBool("is_doublejump",false);        
        }

        if(my_transform.position.y <=-4.0f)
        {
            Character_Die();
            GravityZero();
        }
        if(my_transform.position.x <=-11.0f)
        {
            Character_Die();
            GravityZero();
        }
        if (is_rideroap && !isOnMouseDown)
        {
            AddDownforce();
        }
	}


    public void Jump()
    {
        if(isAlive)
        {
            if(jump_count>0)
            {
                isOnMouseDown = true; 
                jump_count--;
                my_rig.velocity = Vector2.zero;
                my_rig.AddForce(Vector2.up * jump_force);
                if(jump_count==1)
                {
                    SoundManager.Instace.PlayJumpSound();
                    my_animator.SetBool("is_jump", true);
                }
                else if(jump_count==0)
                {
                    SoundManager.Instace.PlayJumpSound();
                    my_animator.SetBool("is_doublejump",true);
                }
                        
            }
        }
    }

    private void GravityZero()
    {
        my_rig.gravityScale = 0.0f;
        my_rig.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Roap"))
        {
            my_animator.SetBool("is_roap",true); 
            is_rideroap = true;     
        }
        if(col.CompareTag("Coin"))
        {
            SoundManager.Instace.PlayCoinSound();
            GameManager.Instance.Get_My_Coin(1);
            Destroy(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Roap"))
        {
            leave_roap();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Roap") && is_rideroap)
        {  
            if (col.transform.position.y - 1 > my_transform.position.y)
            {
                GravityZero();

            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Obstacle"))
        {
            //장애물에 부딪혔을때, 캐릭터 애니메이션 정지 + 바닥 정지 + 노래정지 + Result출력
            Character_Die();
            
        }
    }

    
    void AddDownforce()
    {
         my_rig.gravityScale = 2.0f;
         my_rig.AddForce(Vector2.down * jump_force);
         is_rideroap = false;
         my_animator.SetBool("is_roap",false); 
    }

    void Character_Die()
    {
        if (!my_animator.GetBool("is_die"))
        {
            SoundManager.Instace.PlayGame_Over();
            GroundManager.Instance.Set_Move = false;
            my_animator.SetBool("is_die", true);
            isAlive = false;
        }
    }

    public void leave_roap()
    {
        isOnMouseDown = false;

        if (is_rideroap)
        {
           AddDownforce();
        }
    }


}
