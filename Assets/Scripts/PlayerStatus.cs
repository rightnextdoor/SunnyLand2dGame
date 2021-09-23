using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float startingHealth = 3f;
   
    private float currentHealth;
    public Animator animator;

    private void Start()
    {
        
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.K)))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            HealPlayer(1);
        }
    }

    public float getStartingHealth() {
        return startingHealth;
    }

    public float getPlayerHealth() {
        return currentHealth;
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        
        if (currentHealth <= 0f) {
            Die(this);
        }
        Debug.Log("Player is health is: " + currentHealth);
    }

    public void HealPlayer(float heal) {
        currentHealth += heal;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        Debug.Log("Player is health is: " + currentHealth);
    }

    private void Die(PlayerStatus player) {
        Debug.Log("Player is dead!");
        StartCoroutine(waitTime(player));
       
    }

    private IEnumerator waitTime(PlayerStatus player)
    {
        animator.SetTrigger("death");
        yield return new WaitForSeconds(1f);
        GameMaster.KillPlayer(player);
     }
}
