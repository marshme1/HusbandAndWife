using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>())//если попадает по объекту, на котором висит скрипт EnemyHealth, то
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>(); //инициализируем скрипт EnemyHealth
            enemyHealth.TakeDamage(damageAmount);//отнимаем здоровье у этого объекта
        }
    }
}