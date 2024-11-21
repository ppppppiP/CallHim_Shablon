using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.Events;
using YG;
using Cysharp.Threading.Tasks.Triggers;

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

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoad();
        }

        // Передаем общее количество видео в VideoManager (можно установить вручную или подсчитать в сцене).
        manager.InitializeVideoManager(FindObjectsOfType<LoadVideoButtonClick>().Length);
    }

    public void OpenVideo()
    {
        if (_scores.GetScores() >= Price || isSold)
        {
            if(!isSold)
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