using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeathKazi : MonoBehaviour
{
    public string targetTag;
    public EnemyKazi enemy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {

            enemy.TakeDamage(20, collision.contacts[0].point);
            //enemy.Dead(collision.contacts[0].point);
        }
    }
}
