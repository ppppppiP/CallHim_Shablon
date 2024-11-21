using System.Linq;
using TMPro;
using UnityEngine;
using YG;

public class VideoManager : MonoBehaviour
{
    public static VideoManager Instance { get; private set; }

    public int TotalVideos { get; private set; }
    public int OpenedVideos { get; private set; }

    [SerializeField] TextMeshProUGUI Total;
    [SerializeField] TextMeshProUGUI Opened;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
          
        }
        else
        {
            Destroy(gameObject);
        }
    
        Total.text = TotalVideos.ToString();
     
    }
 
    public void InitializeVideoManager(int totalVideos)
    {
        TotalVideos = totalVideos;
 
        Total.text = TotalVideos.ToString();
    }

    public void SaveVideoState(string videoId, bool isSold)
    {
        if (YandexGame.savesData.videoStates.ContainsKey(videoId))
        {
            YandexGame.savesData.videoStates[videoId] = isSold;
        }
        else
        {
            YandexGame.savesData.videoStates.Add(videoId, isSold);
        }
        UpdateOpenedVideosCount();
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

    private void UpdateOpenedVideosCount()
    {
        OpenedVideos++;
        Opened.text = OpenedVideos.ToString();
    }
}
