using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool gettingKnockedBack { get; private set; }

    [SerializeField] private float knockBackTime = .2f;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockedBack(Transform damageSource, float knockBackThrust) {
        gettingKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;//вычисляем вектор, куда нужно отбросить объект после удара от персонажа 
        rb.AddForce(difference, ForceMode2D.Impulse); //отбрасываем персонажа, который получает удар
        StartCoroutine(KnockRoutine());//стартует коррутина
    }

    private IEnumerator KnockRoutine() {
        yield return new WaitForSeconds(knockBackTime);//спустя время 
        rb.velocity = Vector2.zero;//делаем вектор скорости объекта равном нулю
        gettingKnockedBack = false;
    }
}