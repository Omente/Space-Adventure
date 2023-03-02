using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.PROJECTILE_TAG))
        {
            collision.gameObject.SetActive(false);
        }
        else if ( collision.gameObject.CompareTag(TagManager.METEOR_TAG))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
