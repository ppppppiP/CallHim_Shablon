using TMPro;
using UnityEngine;
using YG;

public class Scores : MonoBehaviour
{
    private int Score;
    public TextMeshProUGUI text;

    private void Awake()
    {
        Score = YandexGame.savesData.money;
        text.text = Score.ToString();
    }
    public int GetScores() => Score;
    public void AddScores(int a) { 
        
        Score += a;
        text.text = Score.ToString();
        YandexGame.savesData.money = Score;
        YandexGame.SaveProgress();
    }
}