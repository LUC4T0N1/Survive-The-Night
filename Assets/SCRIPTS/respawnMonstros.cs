using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnMonstros : MonoBehaviour
{
    public GameObject zumbi;
    public Transform localTransform;
    private int contador = 0;
    public int limite;
    public float tempo;
    private Vector3 local;
    void Start()
    {
        local = localTransform.position;
        Renasce();
    }


    void Renasce()
    {
        if (contador < limite)
        {
            Instantiate(zumbi, local, Quaternion.identity);
            Invoke("Renasce", tempo);
        }
        contador = contador + 1;

    }

}