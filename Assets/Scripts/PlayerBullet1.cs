using UnityEngine;
using System.Collections;

public class PlayerBullet1 : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () 
    {
        
	
	}

    void FixedUpdate() //used when dealing with physics
    {
        
        Vector2 movement = new Vector2 (0, 1); //stores horizontal and vertical in vector
        transform.Translate(movement*speed);
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
