using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame updat
    public static bool isPaused = false;
    public static bool lost = false;
    public GameObject pauseMenuUI;
    public GameObject GameOverMenuUI;
    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameOverMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void GameOver(){
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        lost = true;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Replay(){
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }
    public void Quit(){
        Application.Quit();
    }


}
