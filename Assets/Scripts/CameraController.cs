using UnityEngine;

public class CameraController : MonoBehaviour {
	private const float posZ = -10f;
	public GameObject player;

	void Update() { transform.position = new Vector3(player.transform.position.x, player.transform.position.y, posZ); }
}