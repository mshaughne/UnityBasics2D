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
            // switch to the main menu
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void ObtainCoin()
    {
        coinsObtained++;
        coinsText.text = "Coins = " + coinsObtained;
        Debug.Log("Coins = " + coinsObtained);
    }
}
