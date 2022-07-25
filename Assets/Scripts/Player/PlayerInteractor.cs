using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private FloatVariable stackAmount;
    [SerializeField] private IntVariable currenyAmount;

    private Animator animator;
    public bool endGame = false;

    private void OnEnable() 
    {
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(stackAmount.GetValue() > 35)
        {
            animator.SetBool("isFullRunning", true);
        }
        else
        {
            animator.SetBool("isFullRunning", false);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "collectable")
        {
            if(stackAmount.GetValue() < stackAmount.maxFloatVariable)
            {
                Destroy(other.gameObject);
                stackAmount.Increase(1);
            }
        }
        
        if(other.gameObject.tag == "gold")
        {
            Destroy(other.gameObject);
            currenyAmount.Increase(10);
            PlayerPrefs.SetInt("currency", currenyAmount.GetValue());

            if(PlayerPrefs.HasKey("currency"))
            {
                currenyAmount.SetValue(PlayerPrefs.GetInt("currency"));
            }
            else 
            {
                currenyAmount.SetValue(0);
            }
        }

        if(other.gameObject.tag == "obstacle")
        {
            stackAmount.Decrease(3);
        }

        if(other.gameObject.tag == "finish")
        {
            endGame = true;
            animator.SetTrigger("dance");
        }
    }
}
