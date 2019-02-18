using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame() {

        SceneManager.LoadScene("MainScene");
    }
    public void quitGame() {
        Application.Quit();
        Debug.Log("Game was quit");
    
    }


}
