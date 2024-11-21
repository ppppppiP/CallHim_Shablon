using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOnEvent : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(()=>PlayerController.instance.gameObject.SetActive(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
