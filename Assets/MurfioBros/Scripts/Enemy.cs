using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Collider2D[] m_colliders;
    AudioSource m_audioSource;

    private void Start() {
        m_colliders = GetComponentsInChildren<Collider2D>();
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Kill() {
        m_audioSource.pitch = Random.Range(0.95f, 1.05f);
        m_audioSource.Play();

        Invoke("DisableColliders", .25f);
        Destroy(gameObject, 5f);
    }

    private void DisableColliders() {
        foreach (Collider2D col in m_colliders) {
            col.enabled = false;
        }
    }
}
