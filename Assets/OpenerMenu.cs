using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenerMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(Menu.activeSelf == true)
            Menu.SetActive(false);
            else
            Menu.SetActive(true);
        }
    }
}
