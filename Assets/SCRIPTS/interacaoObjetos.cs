using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interacaoObjetos : MonoBehaviour
{
    public float distanciaInteracao = 5f;
    public bool TemChave;
    public Transform pontoDePartida;
    public GameObject chave;
    public GameObject lanterna;
    public bool podePegarChave;
    public Text pegarText;
    public Text pegarLant;
    public Text pegouLant;
    public bool podePegarLanterna;
    public bool temLanterna;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 shootDirection = pontoDePartida.transform.forward;
            RaycastHit hit;
            if (Physics.Raycast(pontoDePartida.position, shootDirection, out hit, distanciaInteracao))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<abrirPortas>().ChangeDoorState();
                }
                else if (hit.collider.CompareTag("DoorTr") && TemChave)
                {
                    hit.collider.transform.GetComponent<fecharPortas>().ChangeDoorState();
                }
                else if (hit.collider.CompareTag("DoorTr") && !TemChave)
                {
                    hit.collider.transform.GetComponent<fecharPortas>().MostrAe();
                }
            }
        }
        if (podePegarChave)
        {
            if (Input.GetButtonDown("pegar"))
            {
                chave.SetActive(false);
                pegarText.enabled = false;
                TemChave = true;
                podePegarChave = false;
            }
        }
        if (podePegarLanterna)
        {
            if (Input.GetButtonDown("pegar"))
            {
                lanterna.SetActive(false);
                pegarLant.enabled = false;
                podePegarLanterna = false;
                temLanterna = true;
                pegouLant.enabled = true;
                Invoke("tiraTexto", 3);
            }
        }
    }
    private void Start()
    {
        pegarLant.enabled = false;
        pegarText.enabled = false;
        pegouLant.enabled = false;
    }
    private void tiraTexto()
    {
        pegouLant.enabled = false;
    }
}
