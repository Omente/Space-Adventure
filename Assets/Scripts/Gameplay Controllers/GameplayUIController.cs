using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController instance;

    [SerializeField] TextMeshProUGUI waveInfoTxt, shipsDestroyedInfoTxt, meteorsDestroyedInfoTxt;

    private int waveCount = 0, shipsDestroyedCount = 0, meteorsDestroyedCount = 0;
    public int WaveCount { get { return waveCount; } } 
    public int ShipsDestroyedCount { get { return shipsDestroyedCount; } }
    public int MeteorsDestroyedCount { get { return meteorsDestroyedCount; } }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInfo(int infoType)
    {
        switch(infoType)
        {
            case 0:
                waveCount++;
                waveInfoTxt.text = $"Wave: {waveCount}";
                break;
            case 1:
                shipsDestroyedCount++;
                shipsDestroyedInfoTxt.text = $"{shipsDestroyedCount}x";
                break;
            case 2:
                meteorsDestroyedCount++;
                meteorsDestroyedInfoTxt.text = $"{meteorsDestroyedCount}x";
                break;
        }
    }
}
