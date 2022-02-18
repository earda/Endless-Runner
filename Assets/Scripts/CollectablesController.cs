using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesController : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    public AudioClip diamondSound;
    public int diamondsCount=0; 
    private void OnTriggerEnter(Collider other)
    {
        
        AudioSource.PlayClipAtPoint(diamondSound,transform.position);
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
         
        //collision with player
        if (other.gameObject.name != "Player")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        } 
        GameManager.Instance.IncrementScore();
        
        Destroy(gameObject);
    } 

    private void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
