using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class nextLevel : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene("level_2");
    }
}