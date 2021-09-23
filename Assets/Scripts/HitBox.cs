using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitBox : MonoBehaviour
{
    public GameObject Player;
    public EnemyStatus status;
  
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 1000f;

    private bool isEnemyDamage = false;

    private void Start()
    {
        
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isEnemyDamage = true;
            status.enemyTakeDamage();
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void setIsEnemyDamage(bool damage) {
        isEnemyDamage = damage;
    }

    public bool getIsEnemyDamage() {
        return isEnemyDamage;
    }

}
