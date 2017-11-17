using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    void Start ()
    {
        Cursor.visible = true;
    }

	public void Play(){
		SceneManager.LoadScene ("level1");
	}
	public void MainMenu(){
		SceneManager.LoadScene ("Main Menu");
	}
	public void Quit(){
		Application.Quit ();
	}
}
