using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CherryCount))]
public class CherryCollectible : MonoBehaviour
{
    private bool canPickup = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canPickup)
        {
            StartCoroutine(waitTime());
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private IEnumerator waitTime()
    {
        canPickup = false;
        CherryCount count = GetComponent<CherryCount>();
        count.CherryCollected();
        yield return new WaitForSeconds(.5f);
        canPickup = true;
    }
}
