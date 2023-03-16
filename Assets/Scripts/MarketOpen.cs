using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOpen : MonoBehaviour
{

    public GameObject hatObjects;
    public GameObject hat2;
    public void Hat()
    {
        if (!hatObjects.activeSelf)
        {
            hatObjects.SetActive(true);
            hat2.SetActive(false);            
        }
       else
       {
           hatObjects.SetActive(false);
           hat2.SetActive(true);
       }
    }

    public void Hat2()
    {
        if (!hat2.activeSelf){
            hat2.SetActive(true);
        hatObjects.SetActive(false);
        }
        else

        {
            hat2.SetActive(false);
        }
    }
}
