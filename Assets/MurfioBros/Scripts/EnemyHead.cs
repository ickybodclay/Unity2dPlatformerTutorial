using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {

    [SerializeField] Enemy m_enemy;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player" && 
            collision.collider is CircleCollider2D && 
            collision.contacts[0].otherCollider.tag == "Head") {
            m_enemy.Kill();
        }
    }
}
