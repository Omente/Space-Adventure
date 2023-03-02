using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas, highscoreCanvas;

    [SerializeField] TextMeshProUGUI shipsDestroyedHS, meteorsDestroyedHS, wavesSurvivedHS;

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenCloseHighscoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highscoreCanvas.enabled = open;

        if(open)
        {
            DisplayHighscore();
        }
    }

    private void DisplayHighscore()
    {
        shipsDestroyedHS.text = $"x{DataManager.GetData(TagManager.SHIP_DESTROYED_DATA_KEY)}";
        meteorsDestroyedHS.text = $"x{DataManager.GetData(TagManager.METEORS_DESTROYED_DATA_KEY)}";
        wavesSurvivedHS.text = $"Wave: {DataManager.GetData(TagManager.WAVE_NUMBER_DATA_KEY)}";
    }
}
