using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Collider2D[] m_colliders;

    private void Start() {
        m_colliders = GetComponentsInChildren<Collider2D>();
    }

    public void Kill() {
        Invoke("DisableColliders", .25f);
        Destroy(gameObject, 5f);
    }

    private void DisableColliders() {
        foreach (Collider2D col in m_colliders) {
            col.enabled = false;
        }
    }
}
