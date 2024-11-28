using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CameraLook : MonoBehaviour
{
    public static CameraLook Instance { get; private set; }

    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float Sensitivity = 40f;


    public float Smoothing = 0.1f; 
    private Vector2 currentLookAxis;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Sensitivity = YandexGame.savesData.sensitivity;
    }

    void Start()
    {
        currentLookAxis = Vector2.zero; // Инициализация
    }

    void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            LockAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        currentLookAxis = Vector2.Lerp(currentLookAxis, LockAxis, Smoothing * Time.deltaTime);

        XMove = currentLookAxis.x * Sensitivity * Time.deltaTime;
        YMove = currentLookAxis.y * Sensitivity * Time.deltaTime;

        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * XMove);
    }

    public void UpdateSensitivity(float newSensitivity)
    {
        Sensitivity = newSensitivity;
        YandexGame.savesData.sensitivity = newSensitivity;
        YandexGame.SaveProgress();
    }

}

