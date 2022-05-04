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

   /* public TextMeshProUGUI vidaj1Text; //***AQUI EMPIEZA LA VIDA***
    public TextMeshProUGUI vidaj2Text;

    public int vidaJ1 = 3;
    public int vidaJ2 = 3;*/


    private void Awake()
    {
        //latidoAntes.SetActive(true);
        desenfundado.SetActive(false);
        sonidodesenfundado.SetActive(false);
        ComenzarDuelo();
    }

    /*private void Start() // **agregado para la vida**
    {
        vidaj1Text.text = "" + vidaJ1;
        vidaj2Text.text = "" + vidaJ2;
    }*/

    public void ComenzarDuelo()
    {
        tiempoDuelo = Random.Range(tiempoDueloMin, tiempoDueloMax);
        Invoke("Desenfundar", tiempoDuelo);
    }

    /*private void Update()
    {
        vidaj1Text.text = "" + vidaJ1; //**AQUI IGUAL**
        vidaj2Text.text = "" + vidaJ2;
    }*/

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
            player2.PerdidaVidaJ2();
            player1.PerdidaVidaJ2();
            
        }


        if (p2Disparo && !p1Disparo)
        {
            player1.ReproducirAnimacion("Muerte");
            player1.NoAnimacion(); //Cuidado
            player1.PerdidaVidaJ1();
            player2.PerdidaVidaJ1();
             
        }

        if (p1Disparo && p2Disparo)
        {
            if (tiempoP1 < tiempoP2)
            {
                player2.ReproducirAnimacion("Muerte");
                player2.PerdidaVidaJ2();
                player1.PerdidaVidaJ2();


            }
            else
            {
                player1.ReproducirAnimacion("Muerte");
                player1.PerdidaVidaJ1();
                player2.PerdidaVidaJ1();


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

    /*public void PerdidaVidaJ2() //**AQUI QUITAR**
    {
        vidaJ2 -= 1;
    }

    public void PerdidaVidaJ1()
    {
        vidaJ1 -= 1;
    }*/

}
