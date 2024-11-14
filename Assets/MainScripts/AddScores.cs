using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddScores : MonoBehaviour
{
    [Inject] LocalGameManager gameManager;
    [SerializeField] GameObject Sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       {
        gameManager.AddScore();
            LeanPool.Spawn(Sound);
        gameObject.SetActive(false);

    } 
    }
    
}
