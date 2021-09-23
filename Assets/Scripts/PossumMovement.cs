using UnityEngine;

public class PossumMovement : MonoBehaviour
{
    [SerializeField] private float movementDistance = 3f;
    [SerializeField] private float speed = 5f;
    private bool movingLeft = true;
    private float leftEdge;
    private float rightEdge;
    private bool facingLeft = true;

    private void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                movingLeft = false;
                flip();
            }
        }
        else {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                movingLeft = true;
                flip();
            }
        }
    }

    private void flip() {
        facingLeft = !facingLeft;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
