using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetoAparecer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el objeto cuando el jugador entra en el trigger
            objetoAparecer.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactiva el objeto cuando el jugador sale del trigger
            objetoAparecer.SetActive(false);
        }
    }
}
