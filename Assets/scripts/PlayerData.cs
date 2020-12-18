using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int bulle1Amount;
    public int bullet2Amount;
    public int sheeldDrink;
    public int healtDrink;
    public int level;
    public float health;
    public float sheeld;

    public PlayerData (Playerhealth health, Inventory inv)
    {
        this.bulle1Amount = inv.bullet1;
        this.bullet2Amount = inv.bullet2;
        this.sheeldDrink = inv.sheeldDrink;
        this.healtDrink = inv.healthDrink;
        this.level = inv.curentLevel;
        this.health = health.playerHealth;
        this.sheeld = health.playerSheeld;
        
    }
}
