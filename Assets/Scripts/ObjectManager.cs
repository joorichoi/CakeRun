using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

    private static ObjectManager instance;
    public static ObjectManager Instance { get {return instance; } }

    [SerializeField]private GameObject[] prefab_grade;
	// Use this for initialization
	void Awake () {
	
        instance = this;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    

}
