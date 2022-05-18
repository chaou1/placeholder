using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public Transform collectablepostition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        collectablepostition.position += new Vector3(0, 0.1f, 0);
        collectablepostition.position += new Vector3(0, -0.1f, 0);

    }

}
