using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeathMish : MonoBehaviour
{
    public string targetTag;
    public EnemyMish enemy;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == targetTag) {
            enemy.TakeDamage(collision.contacts[0].point);
        }
    }
}
