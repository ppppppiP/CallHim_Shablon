using UnityEngine;
using UnityEngine.Events;
using YG;
using YG.Example;

public class Reward : MonoBehaviour
{
    public UnityEvent EOnShowAdd;
    private string currentVideoId; // Хранит идентификатор текущего видео
    LoadVideoButtonClick l;
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= OnShowAdd;
    }

    public void SetCurrentVideoId(string videoId, LoadVideoButtonClick ll)
    {
        currentVideoId = videoId;
        l = ll;
    }

    public void OnShowAdd(int id)
    {
      

        // Проверка правильного идентификатора рекламы (если нужно)
        if (id == 0 && !string.IsNullOrEmpty(currentVideoId))
        {
            VideoManager.Instance.SaveVideoState(currentVideoId, true);
            l.UpdateLockState();
        }
        EOnShowAdd?.Invoke();
    }

    public void Show()
    {
        YandexGame.RewardVideoEvent += OnShowAdd;
        YandexGame.RewVideoShow(0);
    }
}