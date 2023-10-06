using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f; 
    public float damage = 10.0f; 
    private Transform target;

    void Update()
    {
        // Check if the target exists
        if (target == null)
        {
            Destroy(gameObject); // Destroy the bullet if there's no target
            return;
        }

        // Move towards the target
        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        // Rotate the bullet to face the target (optional)
        //transform.LookAt(target);

        // Check if the bullet has reached the target
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        if (distanceToTarget < 0.1f) // You can adjust this value for precision
        {
            Destroy(gameObject);
        }
    }

    //void HitTarget()
    //{
    //    // Deal damage to the enemy (assuming the enemy has a health component)
    //    EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();

    //    if (enemyHealth != null)
    //    {
    //        enemyHealth.TakeDamage(damage);
    //    }

    //    Destroy(gameObject); // Destroy the bullet upon hitting the target
    //}

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
