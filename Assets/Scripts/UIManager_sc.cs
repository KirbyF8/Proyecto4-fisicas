
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_sc : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EneDefUntilNextRound;
    

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;

 
    
    private SpawManage_sc SpawManager;
   


    private void Start()
    {

       

        Time.timeScale = 0;
        SpawManager = FindObjectOfType<SpawManage_sc>();

        SpawManager.GameHasStarted = false;

       

        HideGameOverPanel();
        HidePauseMenuPanel();

      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                HidePauseMenuPanel();
                SpawManager.GameHasStarted = true;
            }
            else if(!pauseMenu.activeSelf && SpawManager.GameHasStarted == true)
            {
                ShowPauseMenuPanel();
            }
        }
    }


    public void ShowGameOverPanel()
    {
        EnemiesDefUntilNextRound();
        gameOver.SetActive(true);
    }
    public void HideGameOverPanel()
    {
        gameOver.SetActive(false);
    }

    public void ShowMainMenuPanel()
    {
        
        mainMenu.SetActive(true);
    }
    public void HideMainMenuPanel()
    {
        Time.timeScale = 1;
        SpawManager.GameStart();
        mainMenu.SetActive(false);
       
    }

    public void ShowPauseMenuPanel()
    {
        SpawManager.GameHasStarted = false;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void HidePauseMenuPanel()
    {
        
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Reset()
    {
        
        SceneManager.LoadScene(0);
        SpawManager.ResetValues();
    }


    private void EnemiesDefUntilNextRound()
    {
        EneDefUntilNextRound.text = $"Enemies to the next round: {SpawManager.EnemyCount}";
        
    }

    public void ResetToZero()
    {
        SpawManager.ResetValues();
        HideGameOverPanel();
        HidePauseMenuPanel();

    }

}
