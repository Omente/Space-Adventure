using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLifeTimer : MonoBehaviour
{
    [SerializeField] float timer = 3f;

    private void OnEnable()
    {
        Invoke("DeactivateProjectile", timer);
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateProjectile");
    }

    private void DeactivateProjectile()
    {
        if(gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }

}
