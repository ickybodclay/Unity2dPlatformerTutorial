using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour {
    private bool m_isInvulnerable = false;
    private float m_invulnerabiltyTime = 1f;
    private int m_health = 3;
    private Color m_flashColor;
    private float m_flashDuration = 0.25f;

    private SpriteRenderer m_renderer;
    private AudioSource m_audioSource;

    [SerializeField]
    AudioClip m_hitSfx;

    private void Start() {
        m_renderer = GetComponent<SpriteRenderer>();
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (m_isInvulnerable) {
            Flash();
        }
    }

    private void Flash() {
        m_flashColor = m_renderer.color;
        m_flashColor.a = Mathf.Lerp(0, 1f, Mathf.PingPong(Time.time, m_flashDuration) / m_flashDuration);
        m_renderer.color = m_flashColor;    
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Enemy" && 
            collision.collider is BoxCollider2D && 
            collision.contacts[0].otherCollider is BoxCollider2D) {
            TakeDamage();
        }
    }

    private void TakeDamage() {
        if (m_isInvulnerable) return;

        Debug.Log("HIT!");

        m_health--;

        m_audioSource.clip = m_hitSfx;
        m_audioSource.pitch = Random.Range(0.95f, 1.05f);
        m_audioSource.Play();

        if (m_health <= 0) {
            Die();
        }
        else {
            StartCoroutine(PostHitInvulnerablity());
        }
    }

    private void Die() {
        Debug.Log("DEAD");
        gameObject.SetActive(false);
    }

    private IEnumerator PostHitInvulnerablity() {
        m_isInvulnerable = true;
        yield return new WaitForSeconds(m_invulnerabiltyTime);
        m_isInvulnerable = false;

        m_flashColor.a = 1f;
        m_renderer.color = m_flashColor;
    }
}
