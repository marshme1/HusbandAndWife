using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathfinding; //создаём переменную на скрипт 

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();//инициализируем переменную, которая будет ссылаться на скрипт 
        state = State.Roaming;
    }

    private void Start() {
        StartCoroutine(RoamingRoutine());//запускает корутину. Это специальный способ выполнения кода, который можно приостанавливать, а затем продолжать его выполнение
    }

    private IEnumerator RoamingRoutine()//метод определяет корутину. IEnumerator - это тип, который позволяет возвращать последовательность объектов, используемых в цикле{
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);//строка ставит выполнение корутины на паузу на 2 секунды перед продолжение следующей итерации цикла. WaitForSeconds - встроенный класс в юнити, который позволяет ожидать время перед выполнением кода
        }
    }

    private Vector2 GetRoamingPosition() {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    } //возвращаем случайную точку 
}
