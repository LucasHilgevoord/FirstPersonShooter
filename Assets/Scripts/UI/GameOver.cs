using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public AudioClip Click;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Cursor.visible = true;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Menu"))
        {
            audio.PlayOneShot(Click, 0.2F);
            Application.LoadLevel(0);
            
        }
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Quit"))
        {
            Application.Quit();
            audio.PlayOneShot(Click, 0.2F);
        }
    }
}
