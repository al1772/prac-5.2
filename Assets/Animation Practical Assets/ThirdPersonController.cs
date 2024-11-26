using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 15.0f;
    public float runSpeedModifier = 2.0f;
    public float crouchSpeedModifier = 0.5f;
    private Animator animator;

    private CharacterController playerMove;
    private bool jumpHeld = false;

    void Start()
    {
        GameObject firstPersonCrosshair = GameObject.Find("RedDotCrosshair");
        if(firstPersonCrosshair != null)
        {
            firstPersonCrosshair.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponentInChildren<Animator>();
        playerMove = GetComponent<CharacterController>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Vertical") * movementSpeed;
        float direction = Input.GetAxis("Mouse X") * rotationSpeed;

        bool run = Input.GetAxis("Fire3") > 0.1f; // shift
        bool crouch = Input.GetAxis("Fire1") > 0.1f; // ctrl

        if (run && movement > 0.0f)
        {
            movement *= runSpeedModifier;
        }
        else if(crouch)
        {
            movement *= crouchSpeedModifier;
        }

        Vector3 moveThisFrame = new Vector3(0.0f, 0.0f, movement);
        moveThisFrame = transform.TransformDirection(moveThisFrame);

        playerMove.SimpleMove(moveThisFrame);
        transform.Rotate(0.0f, direction, 0.0f);

        bool isJumping = Input.GetAxis("Jump") > 0.1f; // space
        if (isJumping && !jumpHeld)
        {
            jumpHeld = true;
            animator.SetBool("isJumping", true);
        }
        else if (!isJumping && jumpHeld)
        {
            isJumping = false;
            jumpHeld = false;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }

        ApplyAnimations(movement, isJumping, crouch);
    }

    void ApplyAnimations(float movement, bool isJumping, bool crouchHeld)
    {
        /* You can write all of your animation code in here.
         * 
         * The parameters supplied will tell you:
         * 
         * - float movement: how fast the character is moving (negative value if going backwards)
         * - bool isJumping: whether the jump key was pressed this frame (will only be called once per press)
         * - bool isCrouching: whether the crouch key is being held
         */

        if (movement > 0.1f) {
            animator.SetFloat("Speed", movement);
        } else {
            animator.SetFloat("Speed", 0f);
        }

    }
}
