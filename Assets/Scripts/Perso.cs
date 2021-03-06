using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perso : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public bool isJumping;
    
    
    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
         if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
         if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Run", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump")&& !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
