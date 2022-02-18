using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int turnSpeed = 0;
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
          //  CameraManager.Instance.FinalCameraScene();
            CameraManager.Instance.isShake = true;
            playerMovement.Die(); 
        } 
    } 
}
