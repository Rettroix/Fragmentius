using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour 
{
    public GameObject controller;
    public PlayerController controllerScript;
    private GameObject expl;
    public GameObject explosion;
    public GameObject health;
    public GameObject purple;
    private GameObject pickup;
    private int choosePickup;
    private Vector3 playerDirection;
	// Use this for initialization
	void Start () 
    {
        controller = GameObject.FindGameObjectWithTag ("Player");
        controllerScript = controller.GetComponent<PlayerController> ();
        choosePickup = Random.Range (0, 1);
        playerDirection = transform.right;
        Destroy(this.gameObject,5);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.position += playerDirection * 0.05f;
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("bullet")) 
        {
            controllerScript.score++;
            expl = (GameObject) Instantiate (explosion, transform.position, Quaternion.identity);
            pickupSpawn ();

            other.gameObject.SetActive (false);
            gameObject.SetActive (false);
            Destroy (expl, 2);
            Destroy (gameObject,2);

        }

    }

    void pickupSpawn () 
    {
        choosePickup = Random.Range (0, 10);

        if (choosePickup == 0) 
        {
            pickup = (GameObject) Instantiate (health, transform.position, Quaternion.identity);  
        }

        if (choosePickup == 1) 
        {
            pickup = (GameObject) Instantiate (purple, transform.position, Quaternion.identity);  
        }

    }
}
