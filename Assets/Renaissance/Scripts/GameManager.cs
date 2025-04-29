using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    /*
    /// <summary>
    /// an instance of the gamemanager that becomes a static
    /// </summary>
    public static GameManager Instance;
    /// <summary>
    /// the number of coins the player has obtained
    /// </summary>
    public int coinsObtained = 0;
    /// <summary>
    /// the UI asset for the amount of coins we're holding
    /// </summary>
    public TextMeshProUGUI coinsText;


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
    }*/

    /// <summary>
    /// an instance of our game manager, which becomes static
    /// </summary>
    public static GameManager Instance;

    public int coinsObtained = 0;

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

    void Update()
    {
        // if the player presses Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // switch to the main menu
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void ObtainCoin()
    {
        coinsObtained++;
        Debug.Log("Coins = " + coinsObtained);
    }

    /*public void ObtainCoin()
    {
        coinsObtained++;
        Debug.Log("Coins = " +  coinsObtained);

        coinsText.text = "Coins = " + coinsObtained;
    }*/
}
