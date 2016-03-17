using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    private Vector2 pos;

    public void Init()
    {
        pos = transform.position;
    }

    public void Updated(float move_pos)
    {
        transform.Translate(Vector2.left * move_pos);

        if(transform.position.x <= -25.60f)
            transform.position = new Vector2(25.50f,.0f);
    }
	
}
