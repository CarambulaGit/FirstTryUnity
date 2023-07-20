using UnityEngine;

public class MoveController : MonoBehaviour {
	public float moveSpeed = 5f;
	public float multiplierForForce = 5f;
	private Rigidbody2D rb;

	void Start() { rb = GetComponent<Rigidbody2D>(); }

	void Update() {
		Vector3 movement = Vector3.right * Input.GetAxis("Horizontal");
		transform.position += movement * Time.deltaTime * moveSpeed;
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
		  rb.AddForce(Vector2.up * multiplierForForce, ForceMode2D.Impulse);
		}
	}
}