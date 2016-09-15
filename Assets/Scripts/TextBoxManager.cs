using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour 
{

    public GameObject textBox;

    public Text theText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    private int endAtLine;

    public int textState;
    private bool textStateInitiated;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    //audio

    public AudioSource scrollSound;
    // Use this for initialization
    void Start () 
    {
        
        textStateInitiated = true;
        textState = 0;

        if (textfile != null) 
        {
            textLines = (textfile.text.Split('\n'));
        }

        if (endAtLine == 0) 
        {
            endAtLine = textLines.Length - 1;
        }

    }

    void Update()
    {
        //theText.text = textLines [currentLine];
        /////////////////////////////////////////////////////////
        ///State -1/////////////////////////////////////////////
        /// Intro///////////////////////////////////////////////
        if (textState == -10) 
        {   
            startText (3, 0, -9);           
        }

        if (textState == -8) 
        {   
            startText (5, 4, -7);           
        }

        if (textState == -6) 
        {   
            startText (9, 6, -5);           
        }


        /////////////////////////////////////////////////////////
        //State 0///////////////////////////////////////////////

        if (textState == 0) 
        {   
            if (textStateInitiated == true) 
            {
                endAtLine = 4;
                currentLine = 0;
                StartCoroutine (TextScroll (textLines[currentLine]));
                textStateInitiated = false;                
            }

            if (Input.GetButtonDown ("Fire1")) 
            {
                
                if (!isTyping) 
                {
                    currentLine++;

                    if (currentLine > endAtLine) 
                    {
                        textBox.SetActive (false);
                        textStateInitiated = true;
                        textState = 1;
                    } 

                    else 
                    {
                        StartCoroutine (TextScroll (textLines[currentLine]));
                    }
                } 
                else if (isTyping && !cancelTyping) 
                {
                    cancelTyping = true;
                }
            }



        }


        ////////////////////////////////////////////////////////
        ///////State 2/////////////////////////////////////////

        if (textState == 2) 
        {   
            startText (7, 6, 3);           
        }
    





    }

    void startText(int valueToEndAtLine, int valueToCurrentLine, int valueToNextTextState)
    {
        if (textStateInitiated == true) 
        {
            endAtLine = valueToEndAtLine;
            currentLine = valueToCurrentLine;
            textStateInitiated = false;
            StartCoroutine (TextScroll (textLines[currentLine]));
            textBox.SetActive (true);               
        }
        if (Input.GetButtonDown ("Fire1")) 
        {
            if (!isTyping) 
            {
                currentLine++;

                if (currentLine > endAtLine) 
                {
                    textBox.SetActive (false);
                    textStateInitiated = true;
                    textState = valueToNextTextState;
                } 

                else 
                {
                    StartCoroutine (TextScroll (textLines[currentLine]));

                }
            } 
            else if (isTyping && !cancelTyping) 
            {
                cancelTyping = true;
            }


        } 
        
    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            scrollSound.Play ();
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }
}
