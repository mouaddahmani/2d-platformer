using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage;
    public Rigidbody2D rb;
    public Collider2D collide;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //collide = GetComponent<Collider2D>();
        rb.velocity = transform.right * speed;
        
    }

    private void Update()
    {
        
        bool isTochingwalls = collide.IsTouchingLayers(LayerMask.GetMask("Ground"));
        
        if (isTochingwalls )
        {
            Destroy(gameObject);
        }
    }

}
