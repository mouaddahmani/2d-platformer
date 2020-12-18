using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletselecter : MonoBehaviour
{
    public Button axe,star;
    public ColorBlock coloractive,colorinactive;
    public void onAxeselect()
    {
        Wepon.instence.selectedBullets = Wepon.instence.bullet[0];
        axe.colors = coloractive;
        star.colors = colorinactive;
    }

    public void onStarselect()
    {
        Wepon.instence.selectedBullets = Wepon.instence.bullet[1];
        star.colors = coloractive;
        axe.colors = colorinactive;
    }
}
