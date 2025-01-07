using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance to easily access across scenes
    public int deathCount; // Track number of deaths

    public TMP_Text deathCountText; // Optional: Text UI element to display death count

    public int score;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set singleton instance
        }
        else
        {
            Destroy(gameObject); // Prevent multiple instances of GameManager
        }
    }

    // Call this method whenever the player dies
    public void PlayerDied()
    {
        deathCount++; // Increment the death count
        UpdateDeathCountUI();
    }

    // Optionally, update the UI text that displays the death count
    void UpdateDeathCountUI()
    {
        if (deathCountText != null)
        {
            deathCountText.text = "Deaths: " + deathCount.ToString();
        }
    }
}
