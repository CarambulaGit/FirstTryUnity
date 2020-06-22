using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
	private GoodJump gj;

	void Start() { gj = GetComponent<GoodJump>(); }

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") { gj.isGrounded = true; }
	}

	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") { gj.isGrounded = false; }
	}
}