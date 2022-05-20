using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class npcScript : dialogsystem
{
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
  
  
    
    // Start is called before the first frame update
    void Start()
    {   
        DialogBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        dialog();
    }
    protected override void Text()
    {
        contents = sentences[timespoken];
    }
}
