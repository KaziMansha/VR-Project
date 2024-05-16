using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterBossDeathMish : MonoBehaviour
{
    public string targetTag;
    public EnemyBossMish enemy;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == targetTag) {
            enemy.TakeDamage(collision.contacts[0].point);
        }
    }
}
