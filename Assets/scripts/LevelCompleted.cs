using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public Playerhealth health;
    public Inventory inv;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dataholder.Instance.health = health.playerHealth;
        Dataholder.Instance.sheeld = health.playerSheeld;
        Dataholder.Instance.bullet1 = inv.bullet1;
        Dataholder.Instance.bullet2 = inv.bullet2;
        Dataholder.Instance.sheeldDrink = inv.sheeldDrink;
        Dataholder.Instance.healthDrink = inv.healthDrink;
        Savingsystem.SavePlayer(health,inv);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
