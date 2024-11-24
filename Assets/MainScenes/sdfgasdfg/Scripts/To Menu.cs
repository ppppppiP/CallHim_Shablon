using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public int SceneNum;
    void Menu()
    {
        SceneManager.LoadScene(SceneNum);
        Time.timeScale = 1;
    }

}
