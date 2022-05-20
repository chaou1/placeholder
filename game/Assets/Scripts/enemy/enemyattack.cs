using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public GameObject projectile;
    public Vector2 distance = new Vector2();
    public Rigidbody2D rb;
    public float attackCooldown;
    public bool projectileCooldown = false;
    public basicenemymovement be;
  
    enum attatckstate { attack };
    // Start is called before the first frame update
    void Start()
    {
        be = this.gameObject.GetComponent<basicenemymovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (projectileCooldown == false && be.playerInRange == true)
        {
            StartCoroutine(attack());


        }
        IEnumerator attack()
        {
            GameObject projectiles = Instantiate(projectile, this.transform);
            rb = projectiles.GetComponent<Rigidbody2D>();
            projectilePath();
            projectileCooldown = true;
            yield return new WaitForSeconds(attackCooldown);
            projectileCooldown = false;
        }
        void projectilePath()
        {
           
            //bullet path
            distance.x = be.playerPosition.position.x - transform.position.x;
            distance.y = be.playerPosition.position.y - transform.position.y;
            distance.Normalize();
        }

    }
}
