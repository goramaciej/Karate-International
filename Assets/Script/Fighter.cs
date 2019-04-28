using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
    [SerializeField] float walkSpeed = 10;
    [SerializeField] float jumpMultiplier = 0.1f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isJumping = false;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        // Jeśli tutaj wpierdolę jakiś inny tekst
        // to co do jasnej cholery zobaczę w gicie?

        if (isJumping) {
            JumpUpdate();
        }
        AnimatorIsPlaying();

        Debug.Log("JumpUpdate: " + rb.velocity);
    }

    private void Move() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            WalkBack();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            WalkForth();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)  || Input.GetKeyUp(KeyCode.LeftArrow)) {
            StopWalking();
        }


        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // get key so it works only once
            if (!isJumping) {
                Jump();
            }
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            HeadHit();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Kick();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            KickLow();
        }
    }
    
    private void Jump() {
        rb.velocity = new Vector2(0, 15f); // standard jump
        isJumping = true;// from this moment everything is changed every frame by jump update
        anim.SetBool("Jump", true);
    }
    private void JumpUpdate() {
        if (rb.velocity.y > 0) {
            var m2 = Vector2.up * Physics2D.gravity * jumpMultiplier * (Time.deltaTime);
            rb.velocity += m2;
        }else if (rb.velocity.y < 0) {
            var m1 = Vector2.up * Physics2D.gravity * (2f) * (Time.deltaTime);
            rb.velocity += m1;
        } else if (rb.velocity.y < 1 && rb.velocity.y > -1) {
            isJumping = false;
            anim.SetBool("Jump", false);
        }
    }


    private void WalkForth() {        
        Vector3 pos = transform.position;
        transform.position = new Vector2(pos.x + walkSpeed * Time.deltaTime, pos.y);

        if (!isJumping) {
            anim.SetBool("GoForth", true);
        }
    }
    private void WalkBack() {
        Vector3 pos = transform.position;
        transform.position = new Vector2(pos.x - walkSpeed * Time.deltaTime, pos.y);

        if (!isJumping) {
            anim.SetBool("GoForth", true);
        }
    }
    private void StopWalking() {
        anim.SetBool("GoForth", false);
    }


    // punch, kick, head hit
    private void Kick() {
        anim.SetTrigger("KickHigh");
    }
    private void KickLow() {
        anim.SetTrigger("KickLow");
    }
    private void HeadHit() {
        anim.SetTrigger("HeadHit");
    }

    void AnimatorIsPlaying() {
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
    }
}
