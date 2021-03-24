using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject menuUI;

    private KeyCode pauseKey = KeyCode.Escape;
    private ScoreKeeper sc;
    private SetVolume volume;

    private static bool isPaused = false;

    public static bool IsPaused
    {
        get => isPaused;
    }

    void Start()
    {
        sc = FindObjectOfType<ScoreKeeper>();
        volume = FindObjectOfType<SetVolume>();
        menuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            SetPauseStatus(!isPaused);
        }
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void Pause() => SetPauseStatus(true);
    public void Resume() => SetPauseStatus(false);

    public void QuitToMainMenu()
    {
        if (sc)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            //sc.MainMenu(true);
        }
    }

    private void SetPauseStatus(bool status)
    {
        Time.timeScale = status ? 0f : 1f;
        menuUI.SetActive(status);
        isPaused = status;


        if (status)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //Set the Volume to increase or decrease using voice
    public void RestartLevel()// Restart Level Button to Level 1
    {
        //sc.ResetGameScore();
        SceneManager.LoadScene(1);
        
    }

    //Volume up and down
    

    public void BackToMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
        menuUI.SetActive(true);
        
    }
}
