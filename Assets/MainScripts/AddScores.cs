using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddScores : MonoBehaviour
{
    [Inject] LocalGameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       {
        gameManager.AddScore();
        gameObject.SetActive(false);
    } 
    }
    
}
