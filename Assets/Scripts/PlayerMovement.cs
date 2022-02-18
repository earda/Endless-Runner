using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : Singleton<PlayerMovement>
{
    bool alive = true;
    int health = 0;
    public float speed = 5f;
    [SerializeField] Rigidbody rb;
    public Animator animator;
    float horizontalInput;
    //[SerializeField] float moveAdd = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] LayerMask groundMask;
    public bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime ;
        Vector3 horizontalMove =  transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
    } 
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.8f, 1.8f), transform.position.y, transform.position.z);
        horizontalInput = Input.GetAxis("Horizontal");
    } 
    public void Die()
    {
        GameManager.Instance.health[health].SetActive(false);
        health++; 
        if (health==3)
        {
            alive = false;
            UIManager.Instance.Levelfail();
        } 
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            StartCoroutine(DelayLevelCompPanel());
            speed = 0;
            animator.SetFloat("moveVictory", 1f);
        }
    }
    IEnumerator DelayLevelCompPanel()
    {
        yield return new WaitForSeconds(4f);
        UIManager.Instance.FinishLevel();
    }
}
