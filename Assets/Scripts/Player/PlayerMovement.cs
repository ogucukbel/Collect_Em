using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    private Animator animator;

    private void OnEnable() 
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update() 
    {
        if(inputManager.onPointerDown)
        {
            animator.SetBool("isRunning", true);
            transform.position += transform.forward * 6 * Time.deltaTime;

            if(inputManager.direction == InputManager.Direction.Left)
            {
                if(transform.position.x > 9.3f)
                transform.position -= transform.right * 4 * Time.deltaTime;
            }
            else if(inputManager.direction == InputManager.Direction.Right)
            {
                if(transform.position.x < 13)
                transform.position += transform.right * 4 * Time.deltaTime; 
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
