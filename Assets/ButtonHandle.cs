using UnityEngine;
using System.Collections;

public class ButtonHandle : MonoBehaviour {

	public void menu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

	public void startGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

	public void help(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (2);
	}

	public void about(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (3);
	}

	public void exit(){
		Application.Quit ();
	}
}
