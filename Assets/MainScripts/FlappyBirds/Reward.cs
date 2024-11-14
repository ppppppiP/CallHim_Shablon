using UnityEngine;
using UnityEngine.Events;
using YG;
using YG.Example;

public class Reward : MonoBehaviour
{
    public UnityEvent EOnShowAdd;
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += OnShowAdd;
    }

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= OnShowAdd;
    }
    public void OnShowAdd(int id)
    {
        EOnShowAdd?.Invoke();
    }

    public void Show()
    {
        YandexGame.RewVideoShow(0);
    }
}
