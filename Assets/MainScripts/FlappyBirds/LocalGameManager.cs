
using TMPro;
using UnityEngine;
using UnityEngine.Events;

using Zenject;

public class LocalGameManager : MonoBehaviour
{   
    private int score = 0;
    [SerializeField] UnityEvent OnDie;
    [SerializeField] TextMeshProUGUI Text;
    [Inject] Scores scores;

    private void OnEnable()
    {
        score =  PlayerPrefs.GetInt("scores");
        Text.text = score.ToString();
    }

    public void GameOver()
    {
        // ÀŒ√» ¿ Œ ŒÕ◊¿Õ»ﬂ »√–€
        OnDie?.Invoke();
        Debug.Log("œÓË„‡‰");
        PlayerPrefs.SetInt("scores", 0);
    }

    public void ReloadGame()
    {SetNewScores();
        MiniGameController.instance.ReloadGame();
        
    }


    public void PlayMore()
    {
        PlayerPrefs.SetInt("scores", score);
        MiniGameController.instance.ReloadGame();
    }

    public void SetNewScores()
    {
        scores.AddScores(score);
    }
    public void DisableAll()
    {
        MiniGameController.instance.gameObject.SetActive(false);
    }
    public void AddScore()
    {
        score++;
        Text.text = score.ToString();
        Debug.Log("Score: " + score);
    }
}
