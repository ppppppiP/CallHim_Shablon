using UnityEngine;
using System.Collections.Generic;
using Zenject;
using TMPro;
using UnityEngine.Events;
using YG;

public class VideoManager
{
    private Dictionary<string, bool> videoStates = new Dictionary<string, bool>();

    public void SaveVideoState(string videoId, bool isSold)
    {
        YandexGame.savesData.videoStates[videoId] = isSold;
        YandexGame.SaveProgress();
    }

    public bool LoadVideoState(string videoId)
    {
        return YandexGame.savesData.videoStates.ContainsKey(videoId) && YandexGame.savesData.videoStates[videoId];
    }

    public void InitializeVideoState(LoadVideoButtonClick videoButton, string videoId)
    {
        bool isSold = LoadVideoState(videoId);
        videoButton.isSold = isSold;
        videoButton.UpdateLockState();
    }
}

public class LoadVideoButtonClick : MonoBehaviour
{
    [SerializeField] int Price;
    [SerializeField] GameObject Video;
    [SerializeField] GameObject Lock;
    [SerializeField] TextMeshProUGUI text;
    public UnityEvent OnPlay;
    public bool isSold;

    [Inject] Scores _scores;
    [Inject] Reward _rew;
    [Inject] VideoManager manager;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    public void GetLoad()
    {
        if (text != null)
        {
            text.text = YandexGame.savesData.money.ToString();
        }
        manager.InitializeVideoState(this, gameObject.name);
    }

    public void UpdateLockState()
    {
        Lock.SetActive(!isSold);
    }

    public void OpenVideo()
    {
        if (_scores.GetScores() >= Price)
        {
            _scores.AddScores(-Price);
            Video.SetActive(true);
            isSold = true;
            Lock.SetActive(false);
            OnPlay?.Invoke();
            manager.SaveVideoState(gameObject.name, isSold);
            YandexGame.savesData.money = _scores.GetScores();
            YandexGame.SaveProgress();
        }
        else
        {
            _rew.gameObject.SetActive(true);
        }
    }
}
