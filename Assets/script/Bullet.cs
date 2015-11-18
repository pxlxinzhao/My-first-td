using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float angularSpeed;
	public float speed;
	Collider2D target;

	public void setTarget(Collider2D target){
		this.target = target;
	}
	// Use this for initialization

	void TheStart(Collider2D target){
		this.target = target;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, angularSpeed * Time.deltaTime);
		if (target != null) {
//			Debug.Log (string.Format("My target is at x:{0} and y:{1}", target.transform.position.x, target.transform.position.y));
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		} else {
			GameObject.Destroy(gameObject);
		}
	}
}
