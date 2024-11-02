using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private int Score;
    public TextMeshProUGUI text;

    private void Awake()
    {
        text.text = Score.ToString();
    }
    public int GetScores() => Score;
    public void AddScores(int a) { 
        
        Score += a;
        text.text = Score.ToString();
    }
}