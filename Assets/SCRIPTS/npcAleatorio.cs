using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAleatorio : MonoBehaviour
{
    public GameObject npc3;
    public GameObject npc2;
    public GameObject npc1;
    void Start()
    {
        int aleatorio = Random.Range(1, 6);
        if (aleatorio == 1 || aleatorio == 2)
        {
            npc3.SetActive(true);
        }
        else if(aleatorio == 3 || aleatorio == 4)
        {
            npc2.SetActive(true);
        }
        else
        {
            npc1.SetActive(true);
        }

    }
}
