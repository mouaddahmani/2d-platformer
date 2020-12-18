using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temp : MonoBehaviour
{
    
        
        
    public void onMenuClick()
    {
        Admob.instens.ShowInterstitialAds();
        SceneManager.LoadScene("menu");
    }
}
