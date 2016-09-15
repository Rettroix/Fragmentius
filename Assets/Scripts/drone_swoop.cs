using UnityEngine;
using System.Collections;

public class drone_swoop : MonoBehaviour 
{
    public float speed;
    private bool isMoving;
    private bool movementsStarted;
    public int currentMovement;
    public int behaviourState;
    private bool shooting;
    private GameObject[] shoot = new GameObject[3];

    public GameObject bullet;

	// Use this for initialization
	void Start () 
    {
        isMoving = true;
        transform.position = new Vector3 (-4.87f, 5.72f,0f);
        movementsStarted = false;
        currentMovement = 1;
        shooting = false;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (behaviourState == 1) 
        {
            //first position

           

            //strafes left
            if (currentMovement == 1) 
            {
                gotoWayPoint (-3.73f, 2.11f, 2);
                shootFourWayBulletSpurts (1);
                StartCoroutine (waitThisTime (4, 2));
            }

            //strafes right
            if (currentMovement == 2) 
            {
                gotoWayPoint (1.49f, 2.11f, 2);
                shootFourWayBulletSpurts (2);
                StartCoroutine (waitThisTime (4, 3));
            }
            //moves up
            if (currentMovement == 3) 
            {
                gotoWayPoint (0.01f, 5.85f, 0);

                StartCoroutine (waitThisTime (4, 4));
            }
            //up left of screen
            if (currentMovement == 4) 
            {
                gotoWayPoint (-4.87f, 5.72f, 0);

                StartCoroutine (waitThisTime (4, 1));
            }
        }
             

	
	}

    private IEnumerator waitThisTime (float timeLength, int nextMovement)
    {
        yield return new WaitForSeconds(timeLength);
        currentMovement = nextMovement;
                                              
    }

    void gotoWayPoint(float wayPointX, float wayPointY, int nextMovement)
    {
        
        if (transform.position.x >= wayPointX) 
        {
            transform.position -= new Vector3 ((0.1f*speed), 0f,0f);
        }

        if (transform.position.x <= wayPointX) 
        {
            transform.position += new Vector3 ((0.1f*speed), 0f,0f);
        }

        if (transform.position.y >= wayPointY) 
        {
            transform.position -= new Vector3 (0f, (0.1f*speed),0f);
        }

        if (transform.position.y <= wayPointY) 
        {
            transform.position += new Vector3 (0f, (0.1f*speed),0f);
        }
    

    }

    private IEnumerator shootFourWayBulletSpurtsNumerator(int valueCurrentMovement)
    {
        while (currentMovement == valueCurrentMovement) 
        {
            shooting = true;
            yield return new WaitForSeconds(0.25f);

            shoot [0] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0f, -0.5f, 0f), Quaternion.Euler(0f, 0f, 180f)); 
            shoot [1] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0f, -0.5f, 0f), Quaternion.Euler(0f, 0f, 135f));
            shoot [2] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0f, -0.5f, 0f), Quaternion.Euler(0f, 0f, -135f));

            Destroy (shoot [0], 5);
            Destroy (shoot [1], 5);
            Destroy (shoot [2], 5); 


        }

        if (currentMovement != valueCurrentMovement) 
        {
           shooting = false;
        }

    }

    void shootFourWayBulletSpurts(int valueCurrentMovement )
    {
        if (shooting == false) 
        {
            StartCoroutine (shootFourWayBulletSpurtsNumerator (valueCurrentMovement));

        }

    }



}
