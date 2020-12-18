using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frago : MonoBehaviour
{
    public float speed;
    public float distance;
    public float damage;
    public float health;
    private bool movingRight = true;

    public Transform groundDetection;

    private void Update()
    {
        movment();
        chekHealth();
    }

    private void movment()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, 1 << LayerMask.NameToLayer("Ground"));
        if (!groundInfo)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void chekHealth()
    {
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            if(player.GetComponent<Playerhealth>().isSheeldActive)
            {
                player.GetComponent<Playerhealth>().playerSheeld -= damage;
                player.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                player.GetComponent<Playerhealth>().playerHealth -= damage;
                player.GetComponent<SpriteRenderer>().color = Color.red;
            }
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
