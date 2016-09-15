using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    private GameObject expl;
    public GameObject explosion;

    public float counterHealth;
    private bool startCounterHealth;
    public float speed;

    public float score;
    public static float health;
    public float power;
    public float lives;

    private GameObject player;
    private GameObject[] shoot = new GameObject[3];
    public GameObject bullet;


    public Text healthText;
    public Text powerText;
    public Text livesText;

    //Dialogue Related
    public GameObject dialogue;
    public TextBoxManager dialogueScript;


    Animator animator;
	// Use this for initialization
	void Start () 
    {
        dialogueScript = dialogue.GetComponent<TextBoxManager> ();

         
        startCounterHealth = false;
        counterHealth = 0f;
        player = GetComponent <GameObject> (); //sets rb2d to the component rigidbody
        health = 0;
        animator = GetComponent<Animator>();
        lives = 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
        ////////////LIVES//////////////////////////////////////////


        if (lives == 0) {
            livesText.text = "Lives: " + "";
        } else if (lives == 1) {
            livesText.text = "Lives: " + "+";
        } else if (lives == 2) {
            livesText.text = "Lives: " + "++";
        } else if (lives == 3) {
            livesText.text = "Lives: " + "+++";
        } else if (lives == 4) {
            livesText.text = "Lives: " + "++++";
        } else if (lives == 5) {
            livesText.text = "Lives: " + "+++++";
        } else if (lives > 5) {
            lives = 5;
        } else {
            lives = 0;
        }

        if (health == 25) 
        {
            lives++;
            health = 0;
        }

        ///////////////////////////////////////////////////////////
        if (counterHealth >= 6.2f ) 
        {
            animator.SetInteger("hitted", 0);
            startCounterHealth = false;
        }

        if (startCounterHealth == true) 
        {
            counterHealth += 1f * Time.deltaTime;  
        }

        if (startCounterHealth == false) 
        {
            counterHealth = 0f;  
        }

        if (Input.GetButton ("Fire1") && dialogueScript.textState != 0 && dialogueScript.textState != 2) 
        {
            if (power < 5) 
            {
                shoot [0] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0f, 0.5f, 0f), Quaternion.identity);
            } 
            else if (power >= 5 && power < 10)
            {
                shoot [0] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (-0.5f, 0.5f, 0f), Quaternion.identity); 
                shoot [1] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0.5f, 0.5f, 0f), Quaternion.identity); 
            } 

            else 
            {
                shoot [0] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (-0.5f, 0.5f, 0f), Quaternion.Euler(0f, 0f, 45f)); 
                shoot [1] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0.5f, 0.5f, 0f), Quaternion.Euler(0f, 0f, -45f)); 
                shoot [2] = (GameObject)Instantiate (bullet, transform.position + new Vector3 (0f, 0.5f, 0f), Quaternion.identity); 
            }

             

            Destroy (shoot [0], 1);
            Destroy (shoot [1], 1);
            Destroy (shoot [2], 1);
        }
            
        healthText.text = "Fragments: "  + health.ToString();
        powerText.text = "Power: " + power.ToString();

                


	
	}

    void FixedUpdate() //used when dealing with physics
    {
        if (dialogueScript.textState != 0 && dialogueScript.textState != 2) 
        {
            float moveHorizontal = Input.GetAxis ("Horizontal"); //stores horizontal
            float moveVertical = Input.GetAxis ("Vertical"); //stores vertical
            Vector2 movement = new Vector2 (moveHorizontal, moveVertical); //stores horizontal and vertical in vector
            transform.Translate(movement*speed);  
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("health") && startCounterHealth == false) 
        {
            health++;
            other.gameObject.SetActive (false);
            Destroy (other.gameObject);
        }

        if (other.gameObject.CompareTag ("power") && startCounterHealth == false) 
        {
            power++;
            other.gameObject.SetActive (false);
            Destroy (other.gameObject);
        }

        if (other.gameObject.CompareTag ("enemy") && startCounterHealth == false && dialogueScript.textState != 0 && dialogueScript.textState != 2) 
        {
            animator.SetInteger("hitted", 1);
            startCounterHealth = true;
            expl = (GameObject) Instantiate (explosion, transform.position, Quaternion.identity);
            Destroy (expl, 2);
            lives--;
            power = 0;
        }
    }





}
