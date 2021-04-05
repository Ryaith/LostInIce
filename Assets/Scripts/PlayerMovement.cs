using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

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

    Vector2 lastSlideMovement;

    public Animator anim;
    public ParticleSystem ps;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ps.Stop();
    }

    private void Update()
    {
        Debug.Log("Pause Status: " + UiScript.isPaused);
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
        else if (sliding)
        {
            // Lol there has to be a better way to do this
            lastSlideMovement = slideMovement;
            Debug.Log("last slide movement: " + lastSlideMovement);
        }
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.tag == "Ground") {
            isIce = false;
        }
        if (other.gameObject.tag == "Scene2")
        {
            SceneManager.LoadScene("Sample2Scene");
        }
        if (other.gameObject.tag == "Scene3")
        {
            SceneManager.LoadScene("Sample3Scene");
        }
        if (other.gameObject.tag == "Scene1")
        {
            SceneManager.LoadScene("SampleScene");
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
        Vector2 collideNormal = other.contacts[0].normal;
        Debug.Log("collide");
        // Collide check only from the front or else the player gets stuck on side collisions from walls
        if (isIce)
        {
            bool horCollide = Mathf.Abs(collideNormal.x) > Mathf.Abs(collideNormal.y);
            bool verCollide = Mathf.Abs(collideNormal.y) > Mathf.Abs(collideNormal.x);
            Debug.Log("collide up: " + verCollide + "| collide side: " + horCollide + "last slide y: " + (lastSlideMovement.y != 0) + " AND last slide x: " + (lastSlideMovement.x != 0));
            // BLARGH: this is very verbose but basically the collision direction needs to be checked against the last slide direction. Except the last slide direction is stored... somewhere??
            // Anyway this does not work yet... completely. if lastSlideMov replaced by movingHorizontal/Vertical then it works if collision hapens AND the key is being held
            if (verCollide && (lastSlideMovement.y != 0) || horCollide && (lastSlideMovement.x != 0))
            {
                collision = true;
            }
            else
            {
                collision = false;
            }
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

