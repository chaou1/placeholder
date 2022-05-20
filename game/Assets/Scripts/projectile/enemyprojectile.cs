using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 currentdistance;
    public bool test = false;
    public float deathTime;
    enum bulletstate { death };
    // Start is called before the first frame update
    void Start()
    {
        currentdistance = GetComponentInParent<enemyattack>().distance;
        
        StartCoroutine(death());
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + currentdistance * speed * Time.deltaTime);
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            test = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
