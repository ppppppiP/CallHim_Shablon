using UnityEngine;
using Zenject;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;
    [Inject] LocalGameManager _gameManager;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.AddScore();
        }
    }
}