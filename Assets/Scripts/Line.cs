using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {


    private bool is_ringenter;
    private bool is_clicked;
    private Transform ring_transform;

	// Use this for initialization
	void Awake () {
	    is_ringenter = false;
        is_clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ring"))
        {
            is_ringenter = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Ring"))
        {
            if(is_clicked)
            {
                 if(col.transform.position.x<=-7.7f && col.transform.position.x>=-8.2f)
                {
                    Debug.Log("Perfect!");
                }
                else
                {
                    Debug.Log("Cool!");
                }

                Destroy(col.gameObject);
                is_clicked = false;
            }
    
        }
   
    }
    public void Decide_Score()
    {
        if(is_ringenter)
        {
            is_clicked = true;
           
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Ring"))
        {
            Debug.Log("Miss");
            is_ringenter = false;
        }
    }
}
