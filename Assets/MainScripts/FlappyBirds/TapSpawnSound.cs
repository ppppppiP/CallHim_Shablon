using Lean.Pool;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapSpawnSound: MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject Sound;
    public void OnPointerDown(PointerEventData eventData)
    {
        LeanPool.Spawn(Sound);
    }
} 