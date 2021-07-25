using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarRespawns : MonoBehaviour
{

    public GameObject respawn1;
    public GameObject respawn2;
    public GameObject respawn3;
    public GameObject respawn4;
    public GameObject respawn5;
    public GameObject respawn6;
    public GameObject trigger;
    private void OnTriggerEnter(Collider other)
    {
        respawn1.SetActive(true);
        respawn2.SetActive(true);
        respawn3.SetActive(true);
        respawn4.SetActive(true);
        respawn5.SetActive(true);
        respawn6.SetActive(true);
        trigger.SetActive(false);
    }
}
