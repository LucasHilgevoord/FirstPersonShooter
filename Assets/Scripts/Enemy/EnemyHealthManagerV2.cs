using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagerV2 : MonoBehaviour {

	public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <=0f)
        {
            Die();
            ScoreManager.score++;
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
