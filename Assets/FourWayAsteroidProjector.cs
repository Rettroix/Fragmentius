using UnityEngine;
using System.Collections;

public class FourWayAsteroidProjector : MonoBehaviour 
{
    private GameObject aster;
    private GameObject aster2;
    public GameObject asteroid;
    private Vector3 playerPos;
    private Vector3 playerDirection;
    private Quaternion playerRotation;
    public float spawnDistance;
    private Vector3 spawnPos;
    private int numberCount;

	// Use this for initialization
	void Start () 
    {

        spawnDistance = 0.05f;
        numberCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        

        if (numberCount == 10 || numberCount == 20 || numberCount == 30 || numberCount == 40) 
        {
            playerPos = transform.position;
            playerDirection = transform.right;
            playerRotation = transform.rotation;
            spawnPos = playerPos + playerDirection*spawnDistance;
            aster = (GameObject) Instantiate (asteroid, spawnPos, playerRotation);

            
        }


        numberCount++;
        if (numberCount >= 40)
        {
            numberCount = 0;
        }

	}

    void FixedUpdate () 
    {
        transform.Rotate(new Vector3 (0, 0, 250) * Time.deltaTime);

    }
}
