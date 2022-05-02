using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tiempoP1, tiempoP2, tiempoDueloMin, tiempoDueloMax;
    public float tiempoDeEspera;
    public bool p1Disparo;
    public bool p2Disparo;
    public bool puedeComparar;
    public Player player1;
    public Player player2;
    public GameObject desenfundado;
    public GameObject sonidodesenfundado;
    public GameObject latidoAntes;

    private float tiempoDuelo;


    private void Awake()
    {
        //latidoAntes.SetActive(true);
        desenfundado.SetActive(false);
        sonidodesenfundado.SetActive(false);
        ComenzarDuelo();
    }



    public void ComenzarDuelo()
    {
        tiempoDuelo = Random.Range(tiempoDueloMin, tiempoDueloMax);
        Invoke("Desenfundar", tiempoDuelo);
    }



    public void Comparar()
    {
        if (puedeComparar == false)
        {
            return;
        }
        Invoke("CompararGanador", tiempoDeEspera);
        puedeComparar = false;
        Invoke("ResetearDuelo", tiempoDeEspera*2);
    }


    void CompararGanador()
    {

        if (p1Disparo && !p2Disparo)
        {
            player2.ReproducirAnimacion("Muerte");
            player2.NoAnimacion(); //Cuidado

            //player2.PerdidaVidaJ2();
        }


        if (p2Disparo && !p1Disparo)
        {
            player1.ReproducirAnimacion("Muerte");
            player1.NoAnimacion();
        }

        if (p1Disparo && p2Disparo)
        {
            if (tiempoP1 < tiempoP2)
            {
                player2.ReproducirAnimacion("Muerte");
            }
            else
            {
                player1.ReproducirAnimacion("Muerte");
            }
        }

    }

    void ResetearDuelo()
    {
        player1.Resetear();
        player2.Resetear();
        latidoAntes.SetActive(true);
        desenfundado.SetActive(false);
        sonidodesenfundado.SetActive(false);
        puedeComparar = true;

        ComenzarDuelo();
    }

     void Desenfundar()
    {
        latidoAntes.SetActive(false);
        desenfundado.SetActive(true);
        sonidodesenfundado.SetActive(true);
        player1.MostrarFlecha();
        player2.MostrarFlecha();

    }

}
