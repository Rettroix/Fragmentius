using UnityEngine;
using System.Collections;

public class demonIntroMovements : MonoBehaviour {
    public Transform target;
    public float speed;

    Animator animator;


    //Dialogue Related
    public GameObject dialogue;
    public TextBoxManager dialogueScript;
    public int dialogueState;

	// Use this for initialization
    public bool inPosition = false;
	void Start () 
    {
        animator = GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (dialogueScript.textState == -9) 
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);



            if (transform.position == target.position) 
            {
                animator.SetInteger("movement", 1);
                inPosition = true;
                dialogueScript.textState = -8;


            }
             
                    
             
                
                    

        }

	
	}
}
