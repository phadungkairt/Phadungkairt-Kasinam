using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 7;//กำหนดความเร็ว
    public int jumpForce = 200;//กระโดด
    public float moveX;
    public bool isGround; //เช็คว่ายืนอยู่บนพื้น
    private Animator anim;//รับ animator controller
    private Rigidbody2D rb;
    private bool mirrered;
    private AudioSource au;
    public AudioClip jumpClip;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }


    void Update()
    {
        moveX = Input.GetAxis("Horizontal");//แนวนอน
        //กระโดด
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            Jump();
        }

        if (!isGround)
        {
            anim.SetBool("IsJumping", true);
        }
        //เคลื่อนที่
        if (moveX != 0 && isGround)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        // มุม Mirrored
        if (moveX < 0.0f && mirrered == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && mirrered == true)
        {
            FlipPlayer();
        }
        rb.velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void FlipPlayer()
    {
        mirrered = !mirrered;
        Vector2 local = gameObject.transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        isGround = false;
        au.clip = jumpClip;
        au.Play();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Box")
        {
            isGround = true;
            anim.SetBool("IsJumping", false);
        }
        if (other.gameObject.tag == "Endlevel")
        {
            Application.LoadLevel("Home");
        }
    }
}
