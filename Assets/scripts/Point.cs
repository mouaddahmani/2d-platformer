using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Chekpoints chekpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(chekpoint.curentPoint < chekpoint.checkPoints.IndexOf(this.gameObject.transform))
            {
                chekpoint.curentPoint++;
            }
        }
    }
}
