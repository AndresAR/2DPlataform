using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public int jumpHeight;
	public int moveSpeed;
	public int maxJumps;

	private int numJumps; // Saltos máximos permitidos
	private bool facingRight; // Comprueba si estamos viendo a la derecha

	// Use this for initialization
	void Start () {
		numJumps = 0;
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && CanJump()) {
			float x = GetComponent<Rigidbody2D> ().velocity.x;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (x, jumpHeight);
			++numJumps;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			float y = GetComponent<Rigidbody2D> ().velocity.y;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, y);

			// SI está mirando a la derecha, debe rotar
			if (facingRight) {
				Flip ();
			}
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			float y = GetComponent<Rigidbody2D> ().velocity.y;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, y);

			// Si no está mirando a la derecha, que rote
			if (!facingRight) {
				Flip ();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Ground")) {
			numJumps = 0;
		}
	}

	bool CanJump(){
		return numJumps < maxJumps;
	}

	void Flip(){
		Vector3 flipScale;
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();

		flipScale = rigidBody.transform.localScale; // Orietación actual del personaje
		flipScale.x *= -1; // Rota el personaje horizontalmente

		rigidBody.transform.localScale = flipScale;

		facingRight = !facingRight; // Mirando para el otro lado
	}
}
