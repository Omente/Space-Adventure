using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectable : MonoBehaviour
{
    [SerializeField] GameObject[] collectable;

    public void SpawnCollectable()
    {
        if (Random.Range(0, 2) > 0) return;
        Instantiate(collectable[Random.Range(0, collectable.Length)], transform.position, Quaternion.identity);
    }
}
