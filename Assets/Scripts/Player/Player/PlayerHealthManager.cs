using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int startingHealth;
   public int currentHealth;

    public float flashLenght;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public int liveValue = 3;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(currentHealth);

		if(currentHealth <=0)
        {
            gameObject.SetActive(false);
            Application.LoadLevel(2);
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        flashCounter = flashLenght;
        rend.material.SetColor("_Color", Color.red);
        LivesManager.lives -= liveValue;
    }
}
