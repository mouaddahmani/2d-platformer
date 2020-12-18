using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage;
    public Rigidbody2D rb;
    public Collider2D collide;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        bool isTochingwalls = collide.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isTochingwalls)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Playerhealth player = collision.gameObject.GetComponent<Playerhealth>();
            if(player.isSheeldActive)
            {
                player.playerSheeld -= damage;
            }
            else
            {
                player.playerHealth -= damage;
            }
            
            Destroy(gameObject);
        }
    }

}
