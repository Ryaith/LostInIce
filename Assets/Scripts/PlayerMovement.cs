﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool isIce = false;
    public bool collision = false;
    public bool sliding = false;
    public bool stopped = true;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 slideMovement;
    bool movingVertical = false;
    bool movingHorizontal = false;

    private float moveHorizontal;
    private float moveVertical;


    public Animator anim;
    public ParticleSystem ps;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ps.Stop();
    }

    private void Update()
    {
        //Debug.Log("Pause Status: " + UiScript.isPaused);
        if (!UiScript.isPaused)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            movingHorizontal = moveHorizontal != 0f;
            moveVertical = Input.GetAxisRaw("Vertical");
            movingVertical = moveVertical != 0f;
        }
        movement.x = moveHorizontal;
        movement.y = moveVertical;
        stopped = movement.sqrMagnitude < 0.01;

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    IEnumerator Slide(Vector2 slideMovement)
    {
        
        while (isIce && !collision)
        {
            if (ps.isStopped)
                ps.Play();
            rb.MovePosition(rb.position + slideMovement * speed * Time.fixedDeltaTime);
            yield return null;
        }

        ps.Stop();
        sliding = false;
        collision = false;
    }

    void FixedUpdate()
    {
        if (!sliding)
        {
            //Debug.Log((movingHorizontal || movingVertical));
            if (isIce && (movingHorizontal || movingVertical))
            {
                sliding = true;
                slideMovement = movement;
                StartCoroutine(Slide(slideMovement));
            }
            else
            {
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            }
        }
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.tag == "Ground") {
            isIce = false;
        }
        if (other.gameObject.tag == "Scene2")
        {
            UiScript.blackOut = true;
            UiScript.mapToLoad = "Sample2Scene";
        }
        if (other.gameObject.tag == "Scene3")
        {
            UiScript.blackOut = true;
            UiScript.mapToLoad = "Sample3Scene";
        }
        if (other.gameObject.tag == "Scene1")
        {
            UiScript.blackOut = true;
            UiScript.mapToLoad = "SampleScene";
        }
        if (other.gameObject.tag == "Scene4")
        {
            UiScript.blackOut = true;
            UiScript.mapToLoad = "Sample4Scene";
        }
        if (other.gameObject.tag == "MainMenu")
        {
            UiScript.blackOut = true;
            UiScript.mapToLoad = "MainMenu";
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isIce = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground") {
            isIce = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("collide");
        if (isIce)
        {
            collision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (isIce)
        {
            collision = false;
        }
    }
}

