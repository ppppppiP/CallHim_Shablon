using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenerMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Ads;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Menu.activeSelf == true)
            {
                Ads.SetActive(true);
                Menu.SetActive(false);
            }
            else
            {
                Ads.SetActive(false);
                Menu.SetActive(true);
            }
        }

    }
}
