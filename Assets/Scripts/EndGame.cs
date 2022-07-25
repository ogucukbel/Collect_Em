using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private PlayerInteractor playerInteractor;
    [SerializeField] private CanvasController canvasController;
    private ParticleSystem[] confetti;

    private void OnEnable() 
    {
        confetti = GetComponentsInChildren<ParticleSystem>();
    }
    private void Update() 
    {
        if(playerInteractor.endGame)
        {
            foreach(ParticleSystem confetti in confetti)
            {
                confetti.Play();
            }

            canvasController.Win();
        }
    }
}
