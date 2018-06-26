using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // speeds
    private float moveSpeed;
    private float JumpSpeed;

    // rigidbody
    private Rigidbody2D player;

    // ground check
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update () {
        moveSpeed = CrossPlatformInputManager.GetAxis("Horizontal");
        JumpSpeed = CrossPlatformInputManager.GetAxis("Vertical");

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * 10, player.velocity.y);

        if(grounded)
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.velocity.x, JumpSpeed * 15);
    }
}
