using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAudio : MonoBehaviour
{
    public GameObject playerController;
    
    private AudioSource audioSource;
    private PlayerMovementController movementController;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        movementController = playerController.GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && movementController.jumpsRemaining > 0)
        {
            audioSource.Play();
        }
    }
}
