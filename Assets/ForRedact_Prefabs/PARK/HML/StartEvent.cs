using UnityEngine;
using UnityEngine.Events;

public class StartEvent: MonoBehaviour
{
    public UnityEvent onStart;

    private bool isOpen;

    private void Start()
    {
        if(PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            onStart?.Invoke();
        }
    }

    public void SetBoolTrue()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
    }
}