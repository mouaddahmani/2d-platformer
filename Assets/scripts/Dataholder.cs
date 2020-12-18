using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dataholder : MonoBehaviour
{
    public static Dataholder Instance;
    public Loder load;
    public PlayerData data;
    public float health, sheeld;
    public int bullet1, bullet2, sheeldDrink, healthDrink, curentLevel, maxHealth = 100, maxSheeld = 50;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            data = load.data();

        }
        else
        {
            Destroy(gameObject);
        }
        if (data != null)
        {
            bullet1 = data.bulle1Amount;
            bullet2 = data.bullet2Amount;
            sheeldDrink = data.sheeldDrink;
            healthDrink = data.healtDrink;
            health = data.health;
            sheeld = data.sheeld;
            curentLevel = data.level + 1;
        }
        else
        {
            bullet1 = 0;
            bullet2 = 0;
            sheeldDrink = 0;
            healthDrink = 0;
            health = maxHealth;
            sheeld = maxSheeld;
            curentLevel = 1;
        }
        
    }


    private void Start()
    {
        Admob.instens.RequestBanner();
    }
    public void onStartClick()
    {
        SceneManager.LoadScene(curentLevel);
    }
}
