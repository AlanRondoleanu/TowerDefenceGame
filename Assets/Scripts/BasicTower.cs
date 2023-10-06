using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{
    public float attackRange = 5.0f; // Adjust this value to set the tower's attack range
    public float attackCooldown = 2.0f; // Time between attacks
    public Transform gunTransform; // The transform representing where the tower shoots from
    public GameObject bulletPrefab; // The projectile the tower fires
    public GameObject attackRangeCircle;

    private float lastAttackTime;

    void Update()
    {
        // Sets circle range indicator
        attackRangeCircle.transform.localScale = new Vector2(attackRange * 2, attackRange * 2);

        // Check if it's time to attack
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Find nearby enemy objects within the attack range
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange / 2);

            foreach (Collider2D collider in colliders)
            {
                // Check if the collider belongs to an enemy
                EnemyScript enemy = collider.GetComponent<EnemyScript>();

                if (enemy != null)
                {
                    // Attack the enemy
                    Attack(enemy);
                    break; // Stop checking for enemies after the first one is attacked
                }
            }
        }
    }

    void Attack(EnemyScript enemy)
    {
        // Instantiate a bullet and fire it at the enemy
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();

        if (bulletComponent != null)
        {
            bulletComponent.SetTarget(enemy.transform);
        }

        // Update the last attack time
        lastAttackTime = Time.time;
    }
}