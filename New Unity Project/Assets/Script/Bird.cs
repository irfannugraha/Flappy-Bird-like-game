using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private Text scoreText;

    public GameObject bullet;

    private Rigidbody2D rb2D;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && Input.GetKeyDown("space")){
            Jump();
        }
        if (Input.GetKeyDown("right shift"))
        {
            Instantiate(bullet, 
                new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z), 
                Quaternion.identity
                );
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        print("Birb"+other.collider.name);
        animator.enabled = false;
    }

    public bool IsDead(){
        return isDead;
    } 
    
    public void Dead(){
        if (!isDead && OnDead != null){
            OnDead.Invoke();
        }
        isDead = true;
    }   

    void Jump(){
        if (rb2D){
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, upForce)); 
        }

        if (OnJump != null){  
            OnJump.Invoke();
        }
    }

    public void AddScore(int val){
        score+=val;
        if (OnAddPoint != null){
            OnAddPoint.Invoke();
        }
        scoreText.text = score.ToString();
    }


}