using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject projectile;
    public Vector3 mouse ;
    public Transform playerPosition;
    public static Vector2 distance = new Vector2();
    public Rigidbody2D rb;
    public bool projectileCooldown = false;
    [SerializeField] private Camera mainCamera;
    enum attatckstate {attack};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
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
        Vector3 mouseworldposition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseworldposition.z = 0f;
        //bullet path
        distance.x = mouseworldposition.x - transform.position.x;
        distance.y = mouseworldposition.y - transform.position.y;
        distance.Normalize();
       
        Debug.DrawLine(transform.position, Input.mousePosition);
    }
    
}
    
