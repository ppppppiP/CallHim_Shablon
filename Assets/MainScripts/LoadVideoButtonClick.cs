using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.Events;
using YG;

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
        isSold = true;
        Lock.SetActive(!isSold);
    }

    public void OpenVideo()
    {
        if (_scores.GetScores() >= Price || isSold == true)
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
            _rew.SetCurrentVideoId(gameObject.name, this); // Передаем идентификатор видео в Reward
         
        }
    }
}