using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    public Transform playerPosition;
    public Vector2 distance = new Vector2();
    public Rigidbody2D rb;
    public bool projectileCooldown = false;
    enum attatckstate {attack};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && projectileCooldown == false)
        {
            StartCoroutine(attack());
        } 
    }
    IEnumerator attack() 
    {
        GameObject projectiles =  Instantiate(projectile,playerPosition);
        rb = projectiles.GetComponent<Rigidbody2D>();
        projectilePath();
        projectileCooldown = true;
        yield return new WaitForSeconds(2f);
        projectileCooldown = false;
    }
    void projectilePath()
    {
        //bullet path
        distance.x = Input.mousePosition.x - transform.position.x;
        distance.y = Input.mousePosition.y - transform.position.y;
        distance.Normalize();
        rb.MovePosition(rb.position + distance * speed * Time.deltaTime);
        Debug.DrawLine(transform.position, Input.mousePosition);
    }
    
}
    
