using System.Collections;
using UnityEngine;


public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 1f;
    [SerializeField] private float enemyDamage = 1f;
    [SerializeField] private float damageDealt = 1f;
    [SerializeField] private float knockbackForce = 10;
    [SerializeField] private float damageTimeout = 1f;
    
    private float currentHealth;
    private bool canTakeDamage = true;
    
    public GameObject Player;
 
    public HitBox hitBox;
    private Rigidbody2D rb;
    public GameObject deathEffect;

    private void Start()
    {
        
        currentHealth = enemyHealth;
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && canTakeDamage)
        {
            if (!hitBox.getIsEnemyDamage())
            {
                if (collision.gameObject.transform.position.x > transform.position.x)
                {
                    Player.GetComponent<PlayerMovement>().setIsHurt(true);
                    Player.GetComponent<PlayerStatus>().TakeDamage(damageDealt);

                    rb.velocity = new Vector2(knockbackForce, rb.velocity.y);
                }
                else
                {
                    Player.GetComponent<PlayerMovement>().setIsHurt(true);
                    Player.GetComponent<PlayerStatus>().TakeDamage(damageDealt);
                    rb.velocity = new Vector2(-knockbackForce, rb.velocity.y); ;
                }
                Player.GetComponent<PlayerMovement>().setIsHurt(false);
                StartCoroutine(damageTimer());
            }
        }
    }

    private IEnumerator damageTimer() {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }

    public float getEnemyHealth() {
        return currentHealth;
    }

    public void enemyTakeDamage() {
        currentHealth -= enemyDamage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else {
            hitBox.setIsEnemyDamage(false);
        }
    }

    private void Die() {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);

        gameObject.SetActive(false);
        Destroy(gameObject);
     }
}
