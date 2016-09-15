using UnityEngine;
using System.Collections;

public class scrollDownObject : MonoBehaviour 
{
    public float scrollSpeed;
	// Use this for initialization
	void Start () 
    {
        
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position += new Vector3 (0f, scrollSpeed);

        if (transform.position.y < -12) 
        {
            transform.position = new Vector3 (Random.Range (-8.62f, -0.11f), +40);
            transform.Rotate(new Vector3 (0, 0, 100) * Time.deltaTime);
        }
	
	}
}
