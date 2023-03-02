using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private WeaponUpgrade weaponUpgrade;

    private Collectable collectable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectable = collision.gameObject.GetComponent<Collectable>();
            weaponUpgrade.ActivateWeapon((int)collectable.Type);

            if(collectable.Type != CollectableType.Health)
                Destroy(collision.gameObject);
        }
    }
}
