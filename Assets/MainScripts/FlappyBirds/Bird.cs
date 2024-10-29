using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bird : MonoBehaviour
{
    [SerializeField] float m_jumpForce = 5f;
    private Rigidbody2D rb;
    private bool _isDead = false;
    [Inject] LocalGameManager _gameManager; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isDead)
        {
            rb.velocity = Vector2.up * m_jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isDead = true;
        _gameManager.GameOver();
    }
}
