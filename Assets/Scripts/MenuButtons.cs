using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public void StartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void LeaveGame() {
        Debug.Log("Leaving the Game!");
        Application.Quit();
    }
}
