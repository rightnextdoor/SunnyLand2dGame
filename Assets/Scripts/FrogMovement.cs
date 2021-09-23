using System.Collections;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float waitToJump = 2f;

    private bool movingLeft = true;
    private float leftEdge;
    private float rightEdge;
    private bool facingLeft = true;
    private bool isWaiting = false;
    
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        leftEdge = transform.position.x - moveDistance;
        rightEdge = transform.position.x + moveDistance;
    }

    private void Update()
    {
        if (!isWaiting)
        {
            if (movingLeft)
            {
                if (transform.position.x > leftEdge)
                {
                    transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
                    anim.SetBool("isMoving", true);
                    
                }
                else
                {
                    
                    movingLeft = false;
                    StartCoroutine(Wait());
                }
            }
            else
            {
                if (transform.position.x < rightEdge)
                {
                    transform.position = new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
                    anim.SetBool("isMoving", true);
                }
                else
                {
                   
                    movingLeft = true;
                    StartCoroutine(Wait());
                }
            }
            
        }
    }

    private void flip()
    {
        
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private IEnumerator Wait() {
        isWaiting = true;
        anim.SetBool("isMoving", false);
        yield return new WaitForSeconds(waitToJump);
        flip();
        isWaiting = false;
    }
}
