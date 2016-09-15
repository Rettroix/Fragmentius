using UnityEngine;
using System.Collections;

public class intro_manager : MonoBehaviour 
{
    //Dialogue Related
    public GameObject dialogue;
    public TextBoxManager dialogueScript;
    public int dialogueState;


	// Use this for initialization
	void Start () 
    {
        dialogueScript.textState = -10;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}
}
