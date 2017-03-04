using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {

    [SerializeField] Enemy m_enemy;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            m_enemy.Kill();
        }
    }
}
