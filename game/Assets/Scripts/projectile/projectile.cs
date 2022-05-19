using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 currentdistance;
    // Start is called before the first frame update
    void Start()
    {
        currentdistance = playerattack.distance;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + currentdistance * speed * Time.deltaTime);
    }
}
