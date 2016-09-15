using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BG_Manager : MonoBehaviour
{
    public float scrollSpeed;
    private bool[] blockSpawned = new bool[3]; //checks if block is spawned
    public GameObject spaceBlockOne; //the space block one
    public GameObject spaceBlockTwo; //the space block one
    public GameObject spaceBlockThree; //the space block one

    private GameObject[] allSpaceBlocks = new GameObject[3];

    private GameObject[] Block = new GameObject[3];
    private GameObject Block2;
    private bool firstRun;
    private int lastTransformed;
    private int lastLastTransformed;
    public Text transformPostiion;
	// Use this for initialization
	void Start ()
    {
        allSpaceBlocks [0] = spaceBlockOne;
        allSpaceBlocks [1] = spaceBlockTwo;
        allSpaceBlocks [2] = spaceBlockThree;
        firstRun = true;
        lastTransformed = 0;
        for (int i = 0; i <= 2; i++) 
        {
            blockSpawned[i] = false;
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {       
        for (int i = 0; i <= 2; i++) 
        {
            if (firstRun == false && blockSpawned[i] == false) 
            {
                Block[i] = (GameObject) Instantiate (allSpaceBlocks [i], Block[i-1].transform.position + new Vector3 (0f,10f, 0f), Quaternion.identity);
                blockSpawned [i] = true;

            }

            if (firstRun == true ) 
            {
                Block[i] = (GameObject) Instantiate (allSpaceBlocks [i], new Vector3 (-1.24f,0f, 0f), Quaternion.identity);
                firstRun = false;
            }
                

        }



       

	}

    void FixedUpdate()
    {
        for (int i = 0; i <= 2; i++)
        {
            Block[i].transform.position = Block[i].transform.position - new Vector3 (0f, (1f * scrollSpeed), 0f);

            if (Block [i].transform.position.y <= -10f) 
            {
                            
                Block [i].transform.position = Block[lastTransformed].transform.position + new Vector3 (0f, +10f, 0f);

                lastLastTransformed = lastTransformed;
                lastTransformed = i;
                transformPostiion.text = i.ToString();
            }

            if (Block [1].transform.position.y - Block [0].transform.position.y != 10f) 
            {
                Block[1].transform.position = Block[0].transform.position + new Vector3 (0f, (10f), 0f);
            }

            if (Block [2].transform.position.y - Block [1].transform.position.y != 10f) 
            {
                Block[2].transform.position = Block[1].transform.position + new Vector3 (0f, (10f), 0f);
            }
        }


    }
    //TO-DO
    //Make it so that they don't get destroyed but instead transform behind the previous block
}
