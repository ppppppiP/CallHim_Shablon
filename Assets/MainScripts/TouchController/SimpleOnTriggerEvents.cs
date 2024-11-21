using UnityEngine;
using UnityEngine.Events;

public class SimpleOnTriggerEvents: MonoBehaviour
{
    [SerializeField] UnityEvent EOnTriggerEnter;
    [SerializeField] UnityEvent EOnTriggerExit;
    [SerializeField] UnityEvent EOnTriggerStay;

    [SerializeField] KeyCode key;
    [SerializeField] bool IsKeyUse;
    [SerializeField] UnityEvent EOnKeyInTriggerDown;

    [SerializeField] LayerMask DetectLayer;

    private bool isEnter;

    private void OnTriggerEnter(Collider other)
    {
        if ((DetectLayer & (1 << other.gameObject.layer)) != 0)
        {
            isEnter = true;
            EOnTriggerEnter?.Invoke();
            ButtonEventHandler.instance.SetListener(() => MobileInput()) ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((DetectLayer & (1 << other.gameObject.layer)) != 0)
        {
            isEnter = false;
            EOnTriggerExit?.Invoke();
            ButtonEventHandler.instance.RemoveListener();
        }
    }

    private void Update()
    {
        if(isEnter)
        {
            if (IsKeyUse)
            {
                if (Input.GetKeyDown(key))
                {
                    EOnKeyInTriggerDown?.Invoke();
                }
            }
            EOnTriggerStay?.Invoke();
            
        }
    }

    public void MobileInput()
    {
        if (isEnter)
        {
            EOnKeyInTriggerDown?.Invoke();
        }
    }
}