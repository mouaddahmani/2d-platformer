using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    //confige
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 1f;
    //[SerializeField] float climbspeed = 5f;
    
    float moveHorizontaly;
    bool playerIsmoving,facingRight = true;
    //reference
    
    public Rigidbody2D rb;
    public Animator anime;
    public BoxCollider2D feetCollider;
    public Playerhealth health;
    public AudioSource Audio1,Audio2,Audio3;
    public AudioClip clipFeet,clipJump;
    public Chekpoints chekpoints;
    public Uimanager uimanager;
    public bool isTouchingGround, isTouchingbox;
    //float gravityScaleAtStart;
    //CapsuleCollider2D myBodyColider;


    // Start is called before the first frame update

    void Start()
    {
        transform.position = chekpoints.checkPoints[chekpoints.curentPoint].position;
        //rb = GetComponent<Rigidbody2D>();
        //anime = GetComponent<Animator>();
        //health = GetComponent<Playerhealth>();
        //feetCollider = GetComponent<BoxCollider2D>();
        //gravityScaleAtStart = rb.gravityScale;
        //myBodyColider = GetComponent<CapsuleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        isTouchingbox = feetCollider.IsTouchingLayers(LayerMask.GetMask("box"));
        PlayerRun();
        playerJump();
        isPlayerTouchingWater();
        playFeetsoundEffect();
        // playerClimbingLader();

    }


    public void PlayerRun()
    {

        moveHorizontaly = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        Vector2 playerVelocity = new Vector2(moveHorizontaly, rb.velocity.y);
        FlipPlayer();
        rb.velocity = playerVelocity;
        playRuningAnime();


    }
   

    public void playerJump()
    {
        
        if (CrossPlatformInputManager.GetButtonDown("Jump") && (isTouchingGround || isTouchingbox))
        {
            Vector2 jumpVelocity = new Vector2(0, jumpForce);
            rb.velocity += jumpVelocity;
            Audio2.clip = clipJump;
            Audio2.Play();
        }
    }

    

    private void playRuningAnime()
    {
        playerIsmoving = Mathf.Abs(moveHorizontaly) > Mathf.Epsilon;
        
        anime.SetBool("runing", playerIsmoving);
    }

    private void FlipPlayer()
    {
        playerIsmoving = Mathf.Abs(moveHorizontaly) > Mathf.Epsilon;
        if(playerIsmoving)
        {
            

            if (moveHorizontaly<0 && facingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                
            }
            else if(moveHorizontaly > 0 && !facingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = true;
               
            }
        }
        
    }

    public void playFeetsoundEffect()
    {
        playerIsmoving = Mathf.Abs(moveHorizontaly) > Mathf.Epsilon;
        if (playerIsmoving && (isTouchingGround || isTouchingbox))
        {
            if (!Audio1.isPlaying)
            {
                Audio1.clip = clipFeet;
                Audio1.Play();
            }
        }
        else
        {
            Audio1.Stop();
        }
    }

   
    private void isPlayerTouchingWater()
    {
        bool isTouchingWater = feetCollider.IsTouchingLayers(LayerMask.GetMask("water"));
        if (isTouchingWater)
        {
            health.playerHealth = 0f;
        }
    }

    public void resetPlayer()
    {
        Admob.instens.ShowInterstitialAds();
        health.playerHealth = 100;
        health.isPlayerAlive = true;
        uimanager.setGameOverbuttons(!health.isPlayerAlive);
        Audio3.Play();
        uimanager.setPlayButtons(health.isPlayerAlive);
        transform.position = chekpoints.checkPoints[chekpoints.curentPoint].position;

    }


    /*
    private void playClimbingAnime()
    {
        playerIsmoving = Mathf.Abs(moveVerticaly) > Mathf.Epsilon;
        if (playerIsmoving)
        {
            anime.SetBool("isClimbing", playerIsmoving);

        }

    }*/
    /*
   private void playerClimbingLader()
   {
       bool isClimbing = feetCollider.IsTouchingLayers(LayerMask.GetMask("climbing"));
       if (!isClimbing)
       {
           rb.gravityScale = gravityScaleAtStart;
           anime.SetBool("isClimbing", false);
           return;
       }
       moveVerticaly = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
       Vector2 playerVelocity = new Vector2(rb.velocity.x, moveVerticaly * climbspeed);
       rb.velocity = playerVelocity;
       rb.gravityScale = 0f;
       playClimbingAnime();

   }*/
}
