using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Speed for the player
	public float speed = 5;
	
	// Prefab of player bullet
	public GameObject PlayerBullet;

	// Shoot or not
	private bool shouldShoot = true;

	// Get Animator
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Enter left/right
		float x = Input.GetAxisRaw ("Horizontal");

		// Enter top/bottom
		float y = Input.GetAxisRaw ("Vertical");

		// Detect which direction player should move
		Vector2 direction = new Vector2 (x, y).normalized;

		rigidbody2D.velocity = direction * speed;


	}

	void initBullet () {

		Vector3 playerPos = new Vector3(this.transform.position.x + 0.35f, this.transform.position.y + 0.8f, 0);
		
		// Instantiate player bullet
		Instantiate(PlayerBullet, playerPos, this.transform.rotation);
	}

	void OnGUI () {
		Event e = Event.current;

		if (e.isKey && e.keyCode == KeyCode.J) {

			if (shouldShoot == false) {
				shouldShoot = true;
				return;
			} else {

				animator.SetTrigger("triggerAnim");
				shouldShoot = false;
				Invoke("initBullet", 0.45f);

			}

		}
	}
}
