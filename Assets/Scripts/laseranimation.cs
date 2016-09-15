using UnityEngine;
using System.Collections;

public class laseranimation : MonoBehaviour {
    Animator animator;

    //timer realted
    private int timer;
    private bool startTimer;
    //Dialogue Related
    public GameObject demon;
    public demonIntroMovements demonScript;
    public TextBoxManager dialogueScript;

	// Use this for initialization
	void Start () 
    {
        startTimer = true;
        animator = GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (demonScript.inPosition == true) 
        {
            animator.SetInteger("posul", 1 );

            if (startTimer == true) 
            {
                timerTextState (200);
            }

        }
	
	}

    void timerTextState(int forTime)
    {
        if (startTimer = true) 
        {
            timer = 0;
        }

        startTimer = false;
        while (startTimer == false) 
        {
            timer++;
            if (timer > forTime) 
            {
                dialogueScript.textState = -6;
            }
        }
    }
}
