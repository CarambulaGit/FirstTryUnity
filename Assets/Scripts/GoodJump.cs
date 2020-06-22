using System;
using UnityEngine;

public class GoodJump : MonoBehaviour {
	public float jumpVelocity = 5f;
	public float moveSpeed = 5f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public bool isGrounded = false;

	Rigidbody2D rb;

	void Awake() { rb = GetComponent<Rigidbody2D>(); }

	void FixedUpdate() {
		Vector3 movement = Vector3.right * Input.GetAxis("Horizontal");
		transform.position += movement * Time.deltaTime * moveSpeed;

		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded ) {
			rb.velocity = Vector2.up * jumpVelocity;
		}

		if (rb.velocity.y < 0) { // Если падаем 
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;  // Увеличиваем скорость падения
		} else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
}