using UnityEngine;
using UnityEngine.Video;


public class VideoLoader : MonoBehaviour
{
    [HideInInspector] public string videoFileName;
    public int selectedFileIndex;
    private VideoPlayer player;



    private void OnEnable()
    {
        player = GetComponent<VideoPlayer>();

        if (player)
        {
            if (LoadingObject.instance.gameObject != null)
            {
                LoadingObject.instance.gameObject.SetActive(true);
            }

            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            player.url = videoPath;

            player.prepareCompleted += OnVideoPrepared;

            player.Prepare();
        }
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        if (LoadingObject.instance.gameObject != null)
        {
            LoadingObject.instance.gameObject.SetActive(false);
        }

        vp.Play();

        player.prepareCompleted -= OnVideoPrepared;
    }
}
