using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int ammoAmount;
    // Start is called before the first frame update
    void Start()
    {

        if (gameObject.CompareTag("ammo1"))
        {
            ammoAmount = Random.Range(1, 4);
        }
        else if (gameObject.CompareTag("ammo2"))
        {
            ammoAmount = Random.Range(1, 2);
        }
        
        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("ammo1"))
        {
            int bulletamount = collision.gameObject.GetComponent<Inventory>().bullet1;
            int temp = bulletamount + ammoAmount;
            if (temp <= 15)
            {
                collision.gameObject.GetComponent<Inventory>().bullet1 = temp;
                Destroy(gameObject);
            }
            else if (temp > 15)
            {
                collision.gameObject.GetComponent<Inventory>().bullet1 = 15;
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("ammo2"))
        {
            int bulletamount = collision.gameObject.GetComponent<Inventory>().bullet2;
            int temp = bulletamount + ammoAmount;
            if (temp <= 5)
            {
                collision.gameObject.GetComponent<Inventory>().bullet2 = temp;
                Destroy(gameObject);
            }
            else if (temp > 5)
            {
                collision.gameObject.GetComponent<Inventory>().bullet2 = 5;
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("sheeld"))
        {

            if (collision.gameObject.GetComponent<Inventory>().sheeldDrink < 3)
            {
                collision.gameObject.GetComponent<Inventory>().sheeldDrink++;
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<Inventory>().sheeldDrink >= 3)
            {
                Debug.Log("full");
            }
        }
        else if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("health"))
        {

            if (collision.gameObject.GetComponent<Inventory>().healthDrink < 3)
            {
                collision.gameObject.GetComponent<Inventory>().healthDrink++;
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<Inventory>().healthDrink >= 3)
            {
                Debug.Log("full");
            }
        }

    }

}
