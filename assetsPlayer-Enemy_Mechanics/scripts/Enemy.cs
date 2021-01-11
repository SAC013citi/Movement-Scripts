using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy state
public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }

    // This function runs once the enemies health is 0 or below 0.
    // It removes the enemie from the game.
    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    // Applies knockback to the enemy and damage.
    public void Knock(Rigidbody2D rigBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(rigBody, knockTime));
        TakeDamage(damage);
    }

    // Not completed, still have to finish function.
    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Handles when enemy gets attacked by player or other enemy.
    private IEnumerator KnockCo(Rigidbody2D rigBody, float knockTime)
    {
        if (rigBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rigBody.velocity = Vector2.zero;
        }
    }
}
