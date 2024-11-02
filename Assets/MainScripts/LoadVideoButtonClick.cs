using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadVideoButtonClick: MonoBehaviour
{
    private Button _button;
    [SerializeField] int Price;
    [SerializeField] GameObject Video;
    bool isSold;

    [Inject] Scores _scores;
    [Inject] Reward _rew;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OpenVide);
    }

    public void OpenVide()
    {
        if(_scores.GetScores() >= Price)
        {
            _scores.AddScores(-Price);
            Video.SetActive(true);
        }
        else
        {
            _rew.gameObject.SetActive(true);

        }

    }
}