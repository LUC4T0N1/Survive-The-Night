using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareAleatorio : MonoBehaviour
{
    public GameObject jumpScare2;
    public GameObject jumpScare1;
    void Start()
    {
        int aleatorio = Random.Range(1, 6);
        if (aleatorio == 1 || aleatorio == 2 || aleatorio == 3)
        {
            jumpScare1.SetActive(true);
        }
        else 
        {
            jumpScare2.SetActive(true);
        }

    }

}
