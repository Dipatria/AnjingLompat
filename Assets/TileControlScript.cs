using UnityEngine;
using System.Collections;

public class TileControlScript : MonoBehaviour {

	Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D> ();
		rigid.AddForce (Vector2.left * 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			int move = Random.Range (300, 400);
			rigid.AddForce (Vector2.right * move);
		} else {
			rigid.AddForce (Vector2.left * 10);
		}
	}
}
