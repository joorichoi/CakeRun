using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private Transform my_transform;
	// Use this for initialization
	void Awake () {
	
        my_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(my_transform.position);
	}
}
