using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{   
    public Transform collectablepostition;
    public Transform playerposition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        collectablepostition.position += new Vector3(0.005f, 0, 0);
      
       

    }
    
 
}
