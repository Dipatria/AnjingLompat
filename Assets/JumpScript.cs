using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class JumpScript : MonoBehaviour {

	private int score = 0, highscore = 0;
	public GameObject Score, Highscore;
	private Rigidbody2D rigid;
	private Animator anim;
	public AudioClip jump, gameover;
	private AudioSource source;
	float oldvelocity = 0.0f;
	void Awake () {

		source = GetComponent<AudioSource>();
	}
	void playJumpSound(){
		source.PlayOneShot (jump, 2);
	}
	void playGameOverSound(){
		source.PlayOneShot (gameover, 2);
	}

	void Start(){
		highscore = PlayerPrefs.GetInt ("HighScore");
		Highscore.GetComponent<Text> ().text = highscore.ToString();
		Debug.Log (highscore.ToString ());
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
	}
	void Update(){

		if (rigid.velocity.y > 0 && oldvelocity <= 0 ) {
			anim.SetBool ("jump", true);
		}else if (rigid.velocity.y < 0 && oldvelocity >= 0 ) {
			anim.SetBool ("jump", false);
		}

		if (this.transform.position.y <= -8) {
			playGameOverSound ();
			PlayerPrefs.SetInt ("HighScore", highscore);
			UnityEngine.SceneManagement.SceneManager.LoadScene (4);
		}
		oldvelocity = rigid.velocity.y;
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag != "Tile")
			return; 
		if (rigid.velocity.y < 0)
		{
			playJumpSound ();
			score++;
			Score.GetComponent<Text> ().text = score.ToString();
			Debug.Log (score.ToString ());
			if (score > highscore) {
				highscore = score;
				Highscore.GetComponent<Text> ().text = highscore.ToString();
				Debug.Log (highscore.ToString ());
			}
			rigid.velocity =  (Vector2.up * Random.Range (10, 15));
		}
	}
}
