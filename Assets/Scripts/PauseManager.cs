using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    private bool paused;

    public void OnEnable() {
        paused = false;
    }

    public void Update() {
        if (paused) {
            if (Input.GetButtonUp("Pause")) {
                PauseOff();
            }
            return;
        }

        if (Input.GetButtonUp("Pause")) {
            PauseOn();
        }
    }

    public void GoToMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame() {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseOn() {
        Time.timeScale = 0;
        paused = true;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void PauseOff() {
        Time.timeScale = 1;
        paused = false;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void LeaveGame() {
        Debug.Log("Leaving the Game!");
        Application.Quit();
    }

}