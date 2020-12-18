using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int bullet1, bullet2,sheeldDrink,healthDrink,curentLevel;
    public Text  bullet1Text, bullet2Text,sheeldDrinkText,healthDrinktext;
    public Playerhealth health;
    public bool isSheeldDrinkfull = false,ishealthDrinkFull = false;
    bool isSheeldDrinkSelected = false,isHealthDrinkSelected = false;
    // Start is called before the first frame update
    void Start()
    {

        bullet1 = Dataholder.Instance.bullet1;
        bullet2 = Dataholder.Instance.bullet2;
        sheeldDrink = Dataholder.Instance.sheeldDrink;
        healthDrink = Dataholder.Instance.healthDrink;
        curentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        bullet1Text.text = bullet1.ToString();
        bullet2Text.text = bullet2.ToString();
        sheeldDrinkText.text = sheeldDrink.ToString();
        healthDrinktext.text = healthDrink.ToString();
        isSheeldDrinkfull = chekifDrinkFull(sheeldDrink);
        ishealthDrinkFull = chekifDrinkFull(healthDrink);
    }

    bool chekifDrinkFull(int drink)
    {
        if (drink > 0)
        {
            if (drink <= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void onSheeldSelect()
    {
        isSheeldDrinkSelected = true;
        isHealthDrinkSelected = false;
    }

    public void onHealthSelect()
    {
        isSheeldDrinkSelected = false;
        isHealthDrinkSelected = true;
    }
    public void onUse()
    {
       if(isSheeldDrinkSelected && isSheeldDrinkfull)
       {
           
            isSheeldDrinkSelected = false;
            if(health.playerSheeld <50)
            {
                
                health.playerSheeld += 25;
                sheeldDrink--;
            }
  
        }
        else if(isSheeldDrinkSelected && !isSheeldDrinkfull)
        {
            Debug.Log("empty1");
        }

        if(isHealthDrinkSelected && ishealthDrinkFull)
        {
            isHealthDrinkSelected = false;
            if(health.playerHealth <100)
            {
                float hlt = health.playerHealth;
                float temp = hlt + 50;
                if (temp <= 100)
                {
                    health.playerHealth = temp;
                    healthDrink--;
                }
                else if (temp > 100)
                {
                    health.playerHealth = 100;
                    healthDrink--;
                }
            }
            
        }
        else if (isHealthDrinkSelected && !ishealthDrinkFull)
        {
            Debug.Log("empty2");
        }
    }




}
