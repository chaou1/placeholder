using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{
    public Transform playerposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerposition.position += new Vector3(0, 0.01f, 0);
        playerposition.position += new Vector3(0, -0.01f, 0);
        
    }
    
}
