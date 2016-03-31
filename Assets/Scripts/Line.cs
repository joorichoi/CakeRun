using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {



	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ring"))
        {
            col.GetComponent<Ring>().Get_RingEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Ring"))
        {
            Debug.Log("Miss");
            col.GetComponent<Ring>().Get_RingEnter = false;
        }
    }
}
