using System;
using UnityEngine;

public class GoodJump : MonoBehaviour {
	// Вводим параметры
	public float jumpVelocity = 5f;
	public float moveSpeed = 5f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public bool isGrounded = false;
	// Заканчиваем ввод параметров
	private Rigidbody2D rb;

	void Awake() { 
		rb = GetComponent<Rigidbody2D>(); 	// Получаем компонент Rigidbody2D
	}

	void FixedUpdate() {
		Vector3 movement = Vector3.right * Input.GetAxis("Horizontal");		// Получаем Vector3 с координатами (x; 0; 0), где -1 <= x <= 1 
		transform.position += movement * Time.deltaTime * moveSpeed;	// Добавляем к текущим координатам персонажа какую-то величину перемещиния (горизонтального)

		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded ) {		// Если нажата (именно факт нажатия, есть ещё просто GetKey - для проверки нажата ли именно в этот момент
		// и GetKeyUp который выдаёт True в момент отжатия кнопки) кнопка прыжка и блок находится на земле
			rb.velocity = Vector2.up * jumpVelocity;	// Устанавливаеи скорость объекта
		}

		if (rb.velocity.y < 0) { 	// Если падаем 																	
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;  	// Увеличиваем скорость падения
		} else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {	// Если взлетаем и кнопка прыжка не нажата
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;		// Уменьшаем скорость взлёта
		}
	}
}