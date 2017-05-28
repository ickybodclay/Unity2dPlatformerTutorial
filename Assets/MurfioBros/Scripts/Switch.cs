using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    [SerializeField]
    private GameObject[] doors;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Crate") {
            ToggleDoors(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Crate") {
            ToggleDoors(true);
        }
    }

    private void ToggleDoors(bool enabled) {
        foreach (GameObject door in doors) {
            door.SetActive(enabled);
        }
    }
}
