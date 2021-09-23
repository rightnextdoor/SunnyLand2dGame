using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue = 1f;

    private bool canPickup = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canPickup) {
            StartCoroutine(waitTime(collision));
            gameObject.SetActive(false);
             Destroy(gameObject);
            
        }
    }

    private IEnumerator waitTime(Collider2D collider) {
        canPickup = false;
        collider.GetComponent<PlayerStatus>().HealPlayer(healthValue);
        yield return new WaitForSeconds(.5f);
        canPickup = true;
    }
}
