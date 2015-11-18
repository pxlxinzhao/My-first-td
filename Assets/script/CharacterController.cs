using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public GameObject BigExplosion;
	public float speed = 10f;
	public bool hit = true;
	public int fps = 12;
	public float hitSpeed = 1f;
	private Quaternion rotation;
	private Vector3 position;
	private Vector3 tempPos;
	private Camera camera;
	private Animator animator;
	private int counter = 0;
	private bool faceRight = true;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		animator = GetComponent<Animator> ();
		animator.speed = hitSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		counter--;
		if (counter < 0) {
			animator.SetBool("isIdle", true);
		}

		if (Input.GetKey ("right")) {
			faceRight = true;
			rotation = transform.rotation;
			rotation.y = 0;
			transform.rotation = rotation;
			position = transform.position;
			tempPos = camera.WorldToScreenPoint (position);
			tempPos.x += speed;
			position = camera.ScreenToWorldPoint (tempPos);
			transform.position = position;
		}
		if (Input.GetKey ("down")) {
			position = transform.position;
			tempPos = camera.WorldToScreenPoint (position);
			tempPos.y -= speed;
			position = camera.ScreenToWorldPoint (tempPos);
			transform.position = position;
		} 

		if (Input.GetKey ("left")) {
			faceRight = false;
			rotation = transform.rotation;
			rotation.y = 180f;
			transform.rotation = rotation;
			position = transform.position;
			tempPos = camera.WorldToScreenPoint (position);
			tempPos.x -= speed;
			position = camera.ScreenToWorldPoint (tempPos);
			transform.position = position;
		}
		if (Input.GetKey ("up")) {
			position = transform.position;
			tempPos = camera.WorldToScreenPoint (position);
			tempPos.y += speed;
			position = camera.ScreenToWorldPoint (tempPos);
			transform.position = position;
		}
		if (Input.GetKey ("space")) {
			if (counter < 0){
				animator.SetBool ("isIdle", false);
				counter = fps + 1;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log ("Triggered");
		if (col.gameObject.name == "Monster(Clone)") {
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			float x;
			if (faceRight){
				x = transform.position.x + box.offset.x + box.size.x/2;
			}else{
				x = transform.position.x + box.offset.x - box.size.x/2;
			}
			float y = transform.position.y + box.offset.y;
			GameObject bigExpl = Instantiate(BigExplosion, col.transform.position, Quaternion.identity) as GameObject;
		} 
	}
}
