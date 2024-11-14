using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class LoadVideoButtonClick: MonoBehaviour
{
    private Button _button;
    [SerializeField] int Price;
    [SerializeField] GameObject Video;
    [SerializeField] GameObject Lock;
    [SerializeField] TextMeshProUGUI text;
    public UnityEvent OnPlay;
    public bool isSold;

    [Inject] Scores _scores;
    [Inject] Reward _rew;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OpenVide);

        if(text != null)
        {
            text.text = Price.ToString();
        }
        if(isSold == true)
        {
            Lock.SetActive(false);
        }
    }

    public void OpenVide()
    {
        if(_scores.GetScores() >= Price)
        {
            _scores.AddScores(-Price);
            Video.SetActive(true);
            isSold = true;
            Lock.SetActive(false);
            OnPlay?.Invoke();
        }
        else
        {
            _rew.gameObject.SetActive(true);

        }
       
    }
}

