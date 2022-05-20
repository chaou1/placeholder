using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openingDirection;
    public roomTemplates roomtemplate;
    private int rand;
    public bool spawned = false;
    public Vector3 offset = new Vector3(1.715177f, -2.613554f,0);
    // Start is called before the first frame update
    void Start()
    {
        roomtemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false) {  switch (openingDirection)
            {
                case 3:
                    rand = Random.Range(0, roomtemplate.roomT.Length);
                    Instantiate(roomtemplate.roomT[rand], transform.position ,roomtemplate.roomT[rand].transform.rotation);
                    break;
                case 4:
                    rand = Random.Range(0, roomtemplate.roomR.Length);
                    Instantiate(roomtemplate.roomR[rand], transform.position , roomtemplate.roomR[rand].transform.rotation);
                    break;
                case 1:
                    rand = Random.Range(0, roomtemplate.roomD.Length);
                    Instantiate(roomtemplate.roomD[rand], transform.position , roomtemplate.roomD[rand].transform.rotation);
                    break;
                case 2:
                    rand = Random.Range(0, roomtemplate.roomL.Length);
                    Instantiate(roomtemplate.roomL[rand], transform.position, roomtemplate.roomL[rand].transform.rotation);
                    break;
            }
            spawned = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
            {
            Destroy(other.gameObject);
        }
    }

}
