using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baka : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform shootingPoint;
    public float health = 40;
    public float fireRate;
    public float distance = 8f;
    float nextFire;
    Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        nextFire = Time.time + fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        isDead();
        chekIfPlayerInRange();
    }

    public void isDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void chekIfPlayerInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, shootingPoint.right, distance,1<< LayerMask.NameToLayer("player"));
        if(hit)
        {

            anime.SetBool("attacking",true);
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bulletEnemy = Instantiate(enemyBullet, shootingPoint.position, transform.rotation) as GameObject;
            }
           
        }
        else
        {
            anime.SetBool("attacking", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("b1"))
        {
            
            health -= collision.gameObject.GetComponent<Bullet>().damage;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("b2"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
            Destroy(collision.gameObject);
        }
    }
}
