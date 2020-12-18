using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerhealth : MonoBehaviour
{
    public Healthbare healtbar;
    public Sheelbare sheeld;
    public AudioSource Audio;
    public Uimanager uimanager;
    public float maxHealth = 100f;
    public float maxSheeld = 50f;
    public float playerHealth,playerSheeld;
    public bool isPlayerAlive = true,isSheeldActive = true;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = Dataholder.Instance.health;
        healtbar.setMaxhealth(Dataholder.Instance.maxHealth);
        playerSheeld = Dataholder.Instance.sheeld;
        sheeld.setMaxSheeld(Dataholder.Instance.maxSheeld);
    }

    // Update is called once per frame
    void Update()
    {
        healtbar.setHealth(playerHealth);
        sheeld.setSheeld(playerSheeld);
        isPlayerDead();
        chekSheeld();
    }
    
    public void isPlayerDead()
    {
        if (playerHealth <= 0)
        {
            isPlayerAlive = false;
            uimanager.setPlayButtons(isPlayerAlive);
            Audio.Pause();
            uimanager.setGameOverbuttons(!isPlayerAlive);
        }
    }

    public void chekSheeld()
    {
        if(playerSheeld <= 0)
        {
            isSheeldActive = false;
            playerSheeld = 0;
        }else if(playerSheeld <=50)
        {
            isSheeldActive = true;
        }else if(playerSheeld >50)
        {
            playerSheeld = 50;
        }
    }
}
