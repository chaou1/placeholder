using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openingDirection;
    public roomTemplates roomtemplate;
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        roomtemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        switch (openingDirection) 
        {
            case 1:
                rand = Random.Range(0, roomtemplate.roomT.Length);
                Instantiate(roomtemplate.roomT[rand], transform.position, Quaternion.identity);
                break;
            case 2:
                rand = Random.Range(0, roomtemplate.roomR.Length);
                Instantiate(roomtemplate.roomR[rand], transform.position, Quaternion.identity);
                break;
            case 3:
                rand = Random.Range(0, roomtemplate.roomD.Length);
                Instantiate(roomtemplate.roomD[rand], transform.position, Quaternion.identity);
                break;
            case 4:
                rand = Random.Range(0, roomtemplate.roomL.Length);
                Instantiate(roomtemplate.roomL[rand], transform.position, Quaternion.identity);
                break;
        }
    }
}
