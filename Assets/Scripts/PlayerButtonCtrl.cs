using UnityEngine;
using System.Collections;

public class PlayerButtonCtrl : MonoBehaviour {
    [SerializeField] private Line line; 
    
    private Transform ground;
    private Character selectChar;

    void Start()
    {
        ground = GameObject.Find("GroundManager").transform;
        selectChar = GameObject.FindWithTag("Player").GetComponent<Character>();
    }

    #region UI Button Function

    public void OnJumpButton()
    {
        selectChar.Jump();
    }

    public void OnLeaveRoap()
    {
        selectChar.leave_roap();
    }

    public void OnRingButton()
    {
        line.Decide_Score();
    }
    #endregion
}
