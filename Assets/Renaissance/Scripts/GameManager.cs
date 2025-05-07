using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// an instance of our game manager, which becomes static
    /// </summary>
    public static GameManager Instance;
    /// <summary>
    /// how many coins the player has
    /// </summary>
    public int coinsObtained = 0;
    /// <summary>
    /// textmeshpro component for the coin count
    /// </summary>
    public TextMeshProUGUI coinsText;
    /// <summary>
    /// the gameobject that holds the UI and all of its children
    /// </summary>
    public GameObject pauseMenuUI;
    /// <summary>
    /// whether or not the game is currently paused
    /// </summary>
    public bool isPaused = false;

    private List<AudioSource> audioSources = new List<AudioSource>();

    public List<AudioSource> excludedSources;

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
        // sets the pause menu UI and its children to be false
        pauseMenuUI.SetActive(false);

        coinsText.text = "Coins = " + coinsObtained;
    }

    void Update()
    {
        // if the player presses Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // switch to the main menu
            // SceneManager.LoadScene("MainMenuScene");

            if(isPaused)
            {
                // resume the game
                Resume();
            }
            else
            {
                // pause the game
                Pause();
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        ResumeAudio();
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseAudio();
        isPaused = true;
    }

    void PauseAudio()
    {
        // AudioListener.pause = true;

        foreach (AudioSource source in FindObjectsOfType<AudioSource>())
        {
            if (source.isPlaying && !excludedSources.Contains(source))
            {
                source.Pause();
                audioSources.Add(source);
            }
        }
    }

    void ResumeAudio()
    {
        // AudioListener.pause = false;

        foreach (AudioSource source in audioSources)
        {
            if (!source)
            {
                source.UnPause();
            }
        }
    }

    public void BackToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
