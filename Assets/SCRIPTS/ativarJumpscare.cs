using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarJumpscare : MonoBehaviour
{
    public GameObject npc1;
    public AudioSource rosn2;
    public GameObject jogador;

    private void OnTriggerEnter(Collider jogador)
    {
        if (jogador.gameObject.tag == "Player")
        {
            npc1.SetActive(true);
            rosn2.Play();
        }
    }
}
