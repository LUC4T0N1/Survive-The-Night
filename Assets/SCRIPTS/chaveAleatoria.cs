using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaveAleatoria : MonoBehaviour
{
    public GameObject chaveCorredor;
    public GameObject chaveSalaoPrincipal;
    public GameObject chaveSala1;
    public GameObject chaveSala2;

    void Start(){
        int aleatorio = Random.Range(1, 9);
        if(aleatorio == 1 || aleatorio == 2)
        {
            chaveCorredor.SetActive(true);
        }
        else if (aleatorio == 3 || aleatorio == 4)
        {
            chaveSalaoPrincipal.SetActive(true);
        }
        else if (aleatorio == 5 || aleatorio == 6)
        {
            chaveSala1.SetActive(true);
        }
        else 
        {
            chaveSala2.SetActive(true);
        }
    }

}
