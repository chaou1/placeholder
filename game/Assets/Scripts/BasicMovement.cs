using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public int a= 0;
    public Transform playerposition;
 
    // Start is called before the first frame update
    void start() { }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) )
        {
            playerposition.position += new Vector3(0, 0.01f ,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerposition.position += new Vector3(-0.01f, 0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerposition.position += new Vector3(0, -0.01f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerposition.position += new Vector3(0.01f, 0,0);
        }
    }
    
    
}
