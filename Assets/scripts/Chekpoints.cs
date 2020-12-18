using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekpoints : MonoBehaviour
{
    public List<Transform> checkPoints = new List<Transform>();
    public int curentPoint;
    // Start is called before the first frame update
    void Start()
    {
        curentPoint = 0;
    }

    public Transform spawnPoint()
    {
        return checkPoints[curentPoint];
    }
}
