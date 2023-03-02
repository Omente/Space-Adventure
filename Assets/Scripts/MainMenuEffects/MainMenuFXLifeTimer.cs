using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFXLifeTimer : MonoBehaviour
{
    [SerializeField] private float timeToDeactiave = 15f;

    private void OnEnable()
    {
        Invoke("DisableMainMenuFX", timeToDeactiave);
    }

    private void DisableMainMenuFX()
    {
        gameObject.SetActive(false);
    }
}
