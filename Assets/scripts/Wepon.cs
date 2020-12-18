using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{

    public Transform point;
    public GameObject[] bullet;
    public GameObject selectedBullets;
    public static Wepon instence;
    public Animator anime;
    private float nextFire = 0f;
    public Inventory inv;
    public AudioSource Audio;
    public AudioClip clip;
    private void Awake()
    {
         if(instence == null)
        {
            instence = this;
        }
    }
    private void Start()
    {
        //inv = GetComponent<Inventory>();
    }

    public void shoot()
    {
        if(selectedBullets.CompareTag("b1") && Time.time >nextFire)
        {
            if(inv.bullet1 >0)
            {
                anime.SetBool("shooting", true);
                Audio.clip = clip;
                Audio.Play();
                nextFire = Time.time + selectedBullets.GetComponent<Bullet>().fireRate;
                Instantiate(selectedBullets, point.position, point.rotation);
                inv.bullet1--;
            }
            else
            {
                Debug.Log("no amo");
            }
        }else if(selectedBullets.CompareTag("b2") && Time.time > nextFire)
        {
            if(inv.bullet2 >0)
            {
                anime.SetBool("shooting", true);
                Audio.clip = clip;
                Audio.Play();
                nextFire = Time.time + selectedBullets.GetComponent<Bullet>().fireRate;
                Instantiate(selectedBullets, point.position, point.rotation);
                inv.bullet2--;
            }
            else
            {
                Debug.Log("no amo");
            }
        }
        
     
        

    }
    public void stopAnime()
    {
        anime.SetBool("shooting", false);
    }
    
}
