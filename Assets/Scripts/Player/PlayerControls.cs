/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // The player scheme
    private PlayerScheme playerScheme;
    // Reference to the controls
    private InputAction controls;

    // The animator
    private Animator animator;

    private void Awake()
    {
        // Fetch new player scheme
        playerScheme = new PlayerScheme();

        // Fetch animator
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        playerScheme.Attack.Left.performed += Left;
        playerScheme.Attack.Left.Enable();

        playerScheme.Attack.Down.performed += Down;
        playerScheme.Attack.Down.Enable();

        playerScheme.Attack.Up.performed += Up;
        playerScheme.Attack.Up.Enable();

        playerScheme.Attack.Right.performed += Right;
        playerScheme.Attack.Right.Enable();
    }

    private void OnDisable()
    {
        playerScheme.Attack.Left.Disable();
        playerScheme.Attack.Down.Disable();
        playerScheme.Attack.Up.Disable();
        playerScheme.Attack.Right.Disable();
    }

    // Update is called once per frame
    void Update()
    {}

    private void Left(InputAction.CallbackContext context)
    {
        Debug.Log("Left" + context.phase);
        animator.SetTrigger("Left");
        animator.ResetTrigger("Down");
        animator.ResetTrigger("Up");
        animator.ResetTrigger("Right");
    }

    private void Down(InputAction.CallbackContext context)
    {
        Debug.Log("Down" + context.phase);
        animator.ResetTrigger("Left");
        animator.SetTrigger("Down");
        animator.ResetTrigger("Up");
        animator.ResetTrigger("Right");
    }

    private void Up(InputAction.CallbackContext context)
    {
        Debug.Log("Up" + context.phase);
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Down");
        animator.SetTrigger("Up");
        animator.ResetTrigger("Right");
    }

    private void Right(InputAction.CallbackContext context)
    {
        Debug.Log("Right" + context.phase);
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Down");
        animator.ResetTrigger("Up");
        animator.SetTrigger("Right");
    }
}
