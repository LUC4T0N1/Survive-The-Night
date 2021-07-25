using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudarCena : MonoBehaviour
{
    private Scene scene;
    private void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel("Level 2");

}
}
