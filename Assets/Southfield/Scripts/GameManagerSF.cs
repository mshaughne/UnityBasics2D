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
    /// <summary>
    /// is the game paused?
    /// </summary>
    public bool isPaused = false;

    private List<AudioSource> audioSources = new List<AudioSource>();

    public List<AudioSource> excludedAudioSources = new List<AudioSource>();

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
            if (!isPaused)
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
        // this will pause ALL audio by pausing the listener itself!
        //AudioListener.pause = true;

        // this will allow us to only pause specific audio sources!
        // (or more accurately, only leave specific sources UNpaused.)
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            // if the audio source is already playing && it isn't on the excluded list
            if (audio.isPlaying && !excludedAudioSources.Contains(audio))
            {
                audio.Pause();
                // adds the audio source to a list of things to unpause later!
                audioSources.Add(audio);
            }
        }

        // a way to pause all ALREADY ACTIVE audio sources (not new ones!)
        /*
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            // if the audio source is already playing && it isn't on the excluded list
            if (audio.isPlaying)
            {
                audio.Pause();
            }
        }
        */
    }

    public void ResumeAudio()
    {
        //AudioListener.pause = false;

        // a way to re-enable all of the sources in the list we made earlier,
        // as well as clean up that list!
        // note: we can't use foreach here because deleting things from
        // an active foreach loop causes it to error out!
        for(int i = audioSources.Count - 1; i>=0; i--)
        {
            if (audioSources[i])
            {
                audioSources[i].UnPause();
                audioSources.RemoveAt(i);
            }
        }


        // a slightly simple way to reenable all audio sources!
        /*
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (audio)
            {
                audio.UnPause();
            }
        }
        */
        
    }
}