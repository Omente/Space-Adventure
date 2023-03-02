using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance;

    [SerializeField] private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, gameOverCanvas;
    [SerializeField] private TextMeshProUGUI shipsDestroyedFinalInfoTxt, meteorsDestroyedFinalInfoTxt, waveFinalInfoTxt;
    [SerializeField] private TextMeshProUGUI shipsDestroyedHighscoreInfoTxt, meteorsDestroyedHighscoreInfoTxt, waveHighscoreInfoTxt;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void OpenGameOverPanel()
    {
        int shipsDestroyedFinal = GameplayUIController.instance.ShipsDestroyedCount;
        int meteorsDestroyedFinal = GameplayUIController.instance.MeteorsDestroyedCount;
        int waveFinal = GameplayUIController.instance.WaveCount - 1;

        playerInfoCanvas.enabled = shipsAndMeteorInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;



        shipsDestroyedFinalInfoTxt.text = $"x{shipsDestroyedFinal}";
        meteorsDestroyedFinalInfoTxt.text = $"x{meteorsDestroyedFinal}";
        waveFinalInfoTxt.text = $"Wave: {waveFinal}";

        CalculateHighscore(shipsDestroyedFinal, meteorsDestroyedFinal, waveFinal);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void CalculateHighscore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
    {
        int shipsDestroyedHighscore = DataManager.GetData(TagManager.SHIP_DESTROYED_DATA_KEY);
        int meteorsDestroyedHighscore = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA_KEY);
        int waveHighscore = DataManager.GetData(TagManager.WAVE_NUMBER_DATA_KEY);

        if (shipsDestroyedHighscore < shipsDestroyedCurrent)
            DataManager.SaveData(TagManager.SHIP_DESTROYED_DATA_KEY, shipsDestroyedCurrent);
        if (meteorsDestroyedHighscore < meteorsDestroyedCurrent)
            DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA_KEY, meteorsDestroyedCurrent);
        if (waveHighscore < waveCurrent)
            DataManager.SaveData(TagManager.WAVE_NUMBER_DATA_KEY, waveCurrent);

        shipsDestroyedHighscoreInfoTxt.text = $"x{DataManager.GetData(TagManager.SHIP_DESTROYED_DATA_KEY)}";
        meteorsDestroyedHighscoreInfoTxt.text = $"x{DataManager.GetData(TagManager.METEORS_DESTROYED_DATA_KEY)}";
        waveHighscoreInfoTxt.text = $"Wave: {DataManager.GetData(TagManager.WAVE_NUMBER_DATA_KEY)}";
    }
}
