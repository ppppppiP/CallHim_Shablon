using UnityEngine;
using UnityEngine.UI;
using YG;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;

    void Start()
    {
        sensitivitySlider.value = YandexGame.savesData.sensitivity;
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    private void UpdateSensitivity(float newSensitivity)
    {
        CameraLook.Instance.UpdateSensitivity(newSensitivity);
    }
}

