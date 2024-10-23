using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDefaultMatTime = .2f;

    private Material defaultMat;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;

    private void Awake() {
        enemyHealth = GetComponent<EnemyHealth>(); //инициализируем скрипт EnemyHealth
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;//присваивает переменной стартовый материал
    }

    public IEnumerator FlashRoutine()//коррутина
    {
        spriteRenderer.material = whiteFlashMat;//изменяем текущий материал на материал, хранящийся в переменной whiteFlashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);//ждём время
        spriteRenderer.material = defaultMat;//меняем материал обратно на стартовый
        enemyHealth.DetectDeath();//проверяем объект, не умер ли
    }
}