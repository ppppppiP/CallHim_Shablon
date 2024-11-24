using UnityEngine;
using YG;

public class AdCursor: MonoBehaviour
{
    private void Awake()
    {
        YandexGame.CloseFullAdEvent += Curs;
    }

    public void Curs()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}