using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSF : MonoBehaviour
{
    /// <summary>
    /// an instance of our game manager, which becomes static
    /// </summary>
    public static GameManagerSF Instance;
    /// <summary>
    /// how many coins the player has
    /// </summary>
    public int coinsObtained = 0;
    /// <summary>
    /// textmeshpro component for the coin count
    /// </summary>
    public TextMeshProUGUI coinsText;
    /// <summary>
    /// the game object that holds the panel and buttons for the pause menu
    /// </summary>
    public GameObject pauseMenuUI;

    public bool isPaused = false;

    public ParticleSystem victoryParticle1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        coinsText.text = "Coins = " + coinsObtained;
    }

    void Update()
    {
        // if the player presses Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void ObtainCoin()
    {
        coinsObtained++;
        coinsText.text = "Coins = " + coinsObtained;
        Debug.Log("Coins = " + coinsObtained);
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        ResumeAudio();
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        PauseAudio();
        Time.timeScale = 0f;
    }

    public void BackToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SouthfieldMenuScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PauseAudio()
    {
        // this will pause ALL audio by pausing the listener
        //AudioListener.pause = true;

        // covering this on friday!
        // this will allow us to only pause specific audio sources
        /*foreach(AudioSource audio in FindObjectsOfType<AudioSource>())
        {

        }*/
    }

    public void ResumeAudio()
    {
        //AudioListener.pause = false;
    }
}
