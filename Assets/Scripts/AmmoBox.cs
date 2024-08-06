using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int minAmountOfAmmo;
    [SerializeField] private int maxAmountOfAmmo;
    private int actualAmountOfAmmo;

    private void Awake()
    {
        actualAmountOfAmmo = Random.Range(minAmountOfAmmo, maxAmountOfAmmo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.transform.GetComponent<Human>();

        if (player != null)
        {
            player.PickUpAmmo(actualAmountOfAmmo);
            Destroy(gameObject);
        }
    }
}
