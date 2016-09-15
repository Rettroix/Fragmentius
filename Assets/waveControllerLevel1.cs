using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveControllerLevel1 : MonoBehaviour 
{
    public float scoree;

    public GameObject controller;
    public PlayerController controllerScript;

    public int gameState;
    private GameObject fwp;
    private GameObject fwp1;
    private GameObject fwp2;
    private GameObject fwp3;

    public GameObject FourWayAsteroidProjector;

    //Drone
    public GameObject drone_strafer;
    public GameObject[] drnstfr = new GameObject[5];

    public Text objective;

    //Dialogue Related
    public GameObject dialogue;
    public TextBoxManager dialogueScript;
    public int dialogueState;

    //waverelated
    private int currentMovement;
	// Use this for initialization
	void Start () 
    {
        gameState = 0;
        currentMovement = 3;
        controller = GameObject.FindGameObjectWithTag ("Player");
        controllerScript = controller.GetComponent<PlayerController> ();

        dialogueScript = dialogue.GetComponent<TextBoxManager> ();
	
	}
	
	// Update is called once per frame
	void Update () 
    {        
        scoree = controllerScript.score;
        dialogueState = dialogueScript.textState;

        //GameStateStarters////////////////////////////////////
        if (scoree == 50) 
        {
            gameState = 3;
            scoree++;
        }
        ////////////////////////////////////////////////////
        /// 
        /// 
        ////////Events/////////////////////////////////////
        if (gameState == 0) 
        {
            objective.text = "Objective: Survive the asteroids.";  
            fwp = (GameObject) Instantiate (FourWayAsteroidProjector, new Vector3(-1.09f,5.37f,0f), Quaternion.identity);
            fwp1 = (GameObject) Instantiate (FourWayAsteroidProjector, new Vector3(-7.27f,-0.08650517f,0f), Quaternion.identity);
            fwp2 = (GameObject) Instantiate (FourWayAsteroidProjector, new Vector3(4.38f,-1.870757f,0f), Quaternion.identity);
            gameState++;
        }

        if (gameState == 2) 
        {
            Destroy (fwp);
            Destroy (fwp1);
            Destroy (fwp2);


        }


        if (gameState == 3) 
        {
            
            objective.text = "Next objective.";
            if (currentMovement == 3) 
            {
                StartCoroutine (spawnAfterSeconds (3,4));
                
            }


            dialogueScript.textState = 2;
            //gameState++;
        }

        if (gameState == 4) 
        {
            //Destroy (drnstfr[0]);
            //Destroy (drnstfr[1]);
            //Destroy (drnstfr[2]);
        }


	
	}

    private IEnumerator waitThisTime (float timeLength, int nextMovement)
    {
        yield return new WaitForSeconds(timeLength);
        currentMovement = nextMovement;

    }

    private IEnumerator spawnAfterSeconds (int valueCurrentMovement, int nextMovement)
    {
        currentMovement = nextMovement;
        if (nextMovement == currentMovement) 
        {
            drnstfr[0] = (GameObject) Instantiate (drone_strafer, new Vector3(-1.09f,5.37f,0f), Quaternion.identity);
            yield return new WaitForSeconds(2);
            //drnstfr[1] = (GameObject) Instantiate (drone_strafer, new Vector3(-7.27f,-0.08650517f,0f), Quaternion.identity);
            yield return new WaitForSeconds(2);
            drnstfr[2] = (GameObject) Instantiate (drone_strafer, new Vector3(4.38f,-1.870757f,0f), Quaternion.identity);
            yield return new WaitForSeconds(2);

        }


    }
}
