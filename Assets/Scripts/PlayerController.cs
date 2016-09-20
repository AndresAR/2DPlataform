using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public bool grounded;
	public LayerMask whatIsGround;

	private Rigidbody2D myRigidbody;
	private Collider2D myCollider;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space)){
			if(grounded){
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);	
			}
		}
	}
}
