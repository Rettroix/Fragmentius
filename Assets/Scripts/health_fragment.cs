using UnityEngine;
using System.Collections;

public class health_fragment : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Destroy (this.gameObject, 5);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.position += new Vector3 (0f, -0.05f);
	
	}
}
