using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator anim;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    private bool isHurt = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
    }

   private void Update()
    {
        if (!isHurt)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("jump", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        
    }

    public void setIsHurt(bool hurt) {
        isHurt = hurt;
    }

    public void OnLanding () {
        anim.SetBool("jump", false);
    }

    public void OnCrouching(bool isCrouching) {
        anim.SetBool("crouch", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    

}
