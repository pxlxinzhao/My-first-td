using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	public float range;
	public GameObject theBullet;
	public float cooldown;
	public float bullet_speed;
	float real_range;
	float cooling;
	bool firstshoot = true;
	bool canshoot = false;
	Collider2D target_collider;
	Queue targetQueue = new Queue();

	// Use this for initialization
	void Start () {
		if (cooldown < 0) {
//			Debug.Log("cooldown time must be positive");
		}
		real_range = range;
		cooling = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (canshoot) {
			cooling -= Time.deltaTime;
			if (target_collider == null){
				Deque(targetQueue);
			}
			else if (cooling < 0){
				shoot (target_collider.transform.position);
				cooling = cooldown;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.name == "Monster(Clone)") {
			targetQueue.Enqueue(col);
//			Debug.Log (targetQueue.Count);
			canshoot = true;
		} else {
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Deque (targetQueue);
		if (targetQueue.Count == 0) {
			canshoot = false;
		}
	}

	void shoot(Vector3 target){
		if (target == null) {
			return;
		}
		GameObject bullet = Instantiate (theBullet, transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Bullet>().setTarget(target_collider);
		bullet.GetComponent<Bullet> ().speed = bullet_speed;
	}

	void Deque(Queue queue){
		if (queue.Count > 0) {
//			Debug.Log("Start deque");
			Collider2D col = (Collider2D)queue.Dequeue();
			if (col == null){
//				Debug.Log("is null");
				Deque (queue);
			}else{
//				Debug.Log("set target collider");
				target_collider = col;
			}
		}else{
			return;
		}
	}
}
