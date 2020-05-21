using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 25f;
    public bool hasJumpPotion = false;
    public bool hasSpeedPotion = false;
    public int jumpPotionModAmount = 0;
    public int speedPotionModAmount = 0;
    public bool dead = false;

    public AudioClip jumpClip;

    float horizontalMove = 0f;
    bool jumpFlag = false;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (jumpFlag)
        {
            animator.SetBool("IsJumping", true);
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (animator.GetBool("IsJumping") == false)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        jump = false;
    }

    void FixedUpdate()
    {

        if (hasJumpPotion)
        {
            if (dead)
            {
                controller.m_JumpForceMod = -600;
            }
            else
            {
                controller.m_JumpForceMod = jumpPotionModAmount;
            }

        }
        else
        {
            if (dead)
            {
                controller.m_JumpForceMod = -600;
            }
            else
            {
                controller.m_JumpForceMod = 0;
            }
        }

        if (hasSpeedPotion)
        {
            if (dead)
            {
                runSpeed = 0f;
            }
            else
            {
                runSpeed = speedPotionModAmount;
            }
            
        }
        else
        {
            if (dead)
            {
                runSpeed = 0f;
            }
            else
            {
                runSpeed = 25f;
            }
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = true;
        }
    }
}
