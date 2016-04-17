using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

    public static ObjectManager Instance { get; private set;}

    [SerializeField] private string[] tagName;

    private GameObject[] grade_check;

    private int grade_number;
	// Use this for initialization

	void Awake () {

        Instance = this;

        grade_check = new GameObject[tagName.Length];
        for (int i = 0; i < tagName.Length; i++)
        {
            grade_check[i] = GameObject.FindWithTag(tagName[i]);
        }

        for (int i = 0; i < grade_check.Length; i++)
        {
            grade_check[i].SetActive(false);
        }

        grade_number = 0;
	}

    public void Grade_SetActiveTrue(int grade_num)
    {
        grade_check[grade_num].SetActive(true);
        grade_number = grade_num;
        Invoke("Grade_SetActiveFalse",0.3f);
    }

    void Grade_SetActiveFalse()
    {
        grade_check[grade_number].SetActive(false);
        grade_number = 0;
    }
}
