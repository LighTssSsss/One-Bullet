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
    //public GameObject ganadorFinal;

    //public GameObject musica;

    public Animator animatorr;


    private float tiempoDuelo;

    //Paticulas
    //public GameObject efecto;

    //public ContactPoint2D contacto;

    //public Vector3 pos;

    /*public  GameObject a;
    public  GameObject b;*/

    /*public TextMeshProUGUI vidaj1Text; //***AQUI EMPIEZA LA VIDA***
    public TextMeshProUGUI vidaj2Text;

    public int vidaJ1 = 3;
    public int vidaJ2 = 3;

    /*public GameObject ganador1;
    public GameObject ganador2;*/

    private void Awake()
    {
        //latidoAntes.SetActive(true);
        desenfundado.SetActive(false);
        sonidodesenfundado.SetActive(false);
        //ganadorFinal.SetActive(false);
        ComenzarDuelo();

        /*ganador1.SetActive(false);
       ganador2.SetActive(false);*/
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

    public void ProducirAnimacion(string animacionNombre)
    {
        animatorr.Play(animacionNombre);
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
        Invoke("ResetearDuelo", tiempoDeEspera*3); //Antiguotiempo dee espera es = 1.31
    }


    void CompararGanador()
    {

        if (p1Disparo && !p2Disparo)
        {
            player2.ReproducirAnimacion("Muerte");
            player2.NoAnimacion(); //Cuidado
            player2.PerdidaVidaJ2();
            player1.PerdidaVidaJ2();
            Invoke("ApagarFlechas", 0.5f);
            
        }


        if (p2Disparo && !p1Disparo)
        {
            player1.ReproducirAnimacion("Muerte");
            player1.NoAnimacion(); //Cuidado
            player1.PerdidaVidaJ1();
            player2.PerdidaVidaJ1();
            Invoke("ApagarFlechas", 0.5f);

            /*Instantiate(efecto, new Vector3(this.transform.position.x, this.transform.position.y,
                this.transform.position.z), transform.rotation);*/

        }

        if (p1Disparo && p2Disparo)
        {
            if (tiempoP1 < tiempoP2)
            {
                player2.ReproducirAnimacion("Muerte");
                player2.PerdidaVidaJ2();
                player1.PerdidaVidaJ2();
                Invoke("ApagarFlechas", 0.5f);

            }
            else
            {
                player1.ReproducirAnimacion("Muerte");
                player1.PerdidaVidaJ1();
                player2.PerdidaVidaJ1();
                Invoke("ApagarFlechas", 0.5f);

            }

            
        }
        //VolverTiempo();
    }

    void ResetearDuelo()
    {
        if(player1.vidaJ1 <= 0 || player2.vidaJ2 <= 0) //Solo una de las dos se cumplen
        {
            //desenfundado.SetActive(false);
            ProducirAnimacion("Desaparece Desenfundar");
            //Invoke("DesaparicionDesenfundado", 1f);
            //Invoke("MusicaDesactivada", 0.9f);
            //musica.SetActive(false);
            /*player1.DesaparecerFlechas();
            player2.DesaparecerFlechas();*/
            return;
        }
        //Hacer un return
        else
        {
            player1.Resetear();
            player2.Resetear();
            VolverTiempo();
            latidoAntes.SetActive(true);
            desenfundado.SetActive(false);
            sonidodesenfundado.SetActive(false);
            //ganadorFinal.SetActive(false);
            puedeComparar = true;

            ComenzarDuelo();
        }
           
 
        /*player1.Resetear();
        player2.Resetear();
        latidoAntes.SetActive(true);
        desenfundado.SetActive(false);
        sonidodesenfundado.SetActive(false);
        puedeComparar = true;

        ComenzarDuelo();*/
    }

     void Desenfundar()
    {
        latidoAntes.SetActive(false);
        desenfundado.SetActive(true);
        sonidodesenfundado.SetActive(true);
        player1.MostrarFlecha();
        player2.MostrarFlecha();


       player1.CompararVida();
       player2.CompararVida();
      
    }

    /*public void PerdidaVidaJ2() //**AQUI QUITAR**
    {
        vidaJ2 -= 1;
    }

    public void PerdidaVidaJ1()
    {
        vidaJ1 -= 1;
    }

    public void CompararVida()
    {
        if (vidaJ1 > 0 && vidaJ2 > 0)
        {
            return;
        }

        if (vidaJ1 > 0 && vidaJ2 <= 0)
        {
            // Hacer visible el gameobject ganador jugador 1
             Invoke("ganador1", 2f);
            // Detener el reseteo o pausar el juego
            //Hacer aparecer el menu de partida finalizada

        }

        if (vidaJ1 <= 0 && vidaJ2 > 0)
        {
            // Hacer visible el gameobject ganador jugador 2
            Invoke("ganador2", 2f);
            // Detener el reseteo o pausar el juego
            //Hacer aparecer el menu de partida finalizada
        }
    }


    public void AparecerMenu()
    {

    }

    public void MostrarPrimerGanador()
    {
       ganador1.SetActive(true);
    }

    public void MostrarSegunGanador()
    {
        ganador2.SetActive(true);
    }*/


    public void DesaparicionDesenfundado()
    {
       
        desenfundado.SetActive(false);
    }

    public void VolverTiempo()
    {
        p1Disparo = false;
        p2Disparo = false;
        tiempoP1 = 0;
        tiempoP2 = 0;
    }


    public void ApagarFlechas()
    {
        player1.DesaparecerFlechas();
        player2.DesaparecerFlechas();
    }

    /*public void MusicaDesactivada()
    {
        musica.SetActive(false);
    }*/
}
