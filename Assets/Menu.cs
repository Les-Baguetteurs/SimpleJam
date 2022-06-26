using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class Menu : MonoBehaviour
{
    public static bool isPaused = false;  
    public GameObject PauseMenu;
    CanvasGroup Canvas;  
    // Start is called before the first frame update
    void Start()
    {
        
        Canvas = GetComponent<CanvasGroup>();
        PauseMenu.transform.localScale = new Vector3(0, 0, 0);  
          
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  
        {
            if (isPaused) {
                Resume();  
            }
            else {
                Pause();  
            }
        }
    }
    public void Resume(){
        Canvas.alpha = 0f;  
        Canvas.blocksRaycasts = false;  
        PauseMenu.transform.localScale = new Vector3(0, 0, 0);  
        Time.timeScale = 1f;  
        isPaused = false;  
          
    }  
    public void Pause(){
        Canvas.alpha = 1f;  
        Canvas.blocksRaycasts = true;  
        PauseMenu.transform.localScale = new Vector3(1, 1, 1);
        Time.timeScale = 0f;  
        isPaused = true;
    }
    

    public void MainMenu(){ 
        SceneManager.LoadScene(1);
    }
    public void quitgame(){
        Application.Quit();  
    }
}
