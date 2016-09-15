using UnityEngine;
using System.Collections;

public class textImporter : MonoBehaviour {

    public TextAsset textfile;
    public string[] textLines;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (textfile != null) 
        {
            textLines = (textfile.text.Split('\n'));
        }
	
	}
}
