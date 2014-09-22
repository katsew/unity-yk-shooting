using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {


	public int hp = 10;
	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		Destroy (c.gameObject);

		anim.Stop();
		anim.PlayQueued("BossDamaged");
		anim.PlayQueued("Boss");

		if (hp <= 0) {
			Destroy (gameObject);
		} else {
			hp = hp - 2;
		}

	}
}
