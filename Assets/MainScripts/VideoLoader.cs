using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public class VideoLoader : MonoBehaviour
{
    [HideInInspector] public string videoFileName; // Имя файла
    public int selectedFileIndex; // Индекс выбранного файла
    private VideoPlayer player;

    private void OnEnable()
    {
        player = GetComponent<VideoPlayer>();

        if (player)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            player.url = videoPath;
            player.Play();
        }
    }
}
