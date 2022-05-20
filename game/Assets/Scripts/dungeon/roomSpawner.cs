using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openingDirection;
    public roomTemplates roomtemplate;
    // Start is called before the first frame update
    void Start()
    {
        roomtemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
