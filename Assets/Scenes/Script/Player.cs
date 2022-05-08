using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //agregado para la vida
using UnityEngine.UI; //Agregado para el menu

public class Player : MonoBehaviour
{
    public Animator animator, animatore;
    public GameManager gameManager;
    public bool player1;
    public bool enTiempo;
    public bool puedoPresionarTecla;
    public bool noPresionarTecla;
    public KeyCode boton,flechaUp,flechaD,flechaAb,flechaIz;
    public SpriteRenderer [] flechas;

    public int numeroFlecha;
    public int numeroApretado;

    public TextMeshProUGUI vidaj1Text; //***AQUI EMPIEZA LA VIDA***
    public TextMeshProUGUI vidaj2Text;

    public int vidaJ1 = 3;
    public int vidaJ2 = 3;

    //Aparicion de victoria y derrota
    public GameObject Ganador1;
    public GameObject Ganador2;

    // Aparicion del menu
    public GameObject botonVolverAjugar;
    public GameObject botonVolverAmenu;
    public Image partidaFinalizada;
    public Image fondoAtras;

    public GameObject ganadorFinal;
    //public GameObject Calavera;

    public void Resetear()
    {
        noPresionarTecla = false;
        enTiempo = false;
        puedoPresionarTecla = false;
        ganadorFinal.SetActive(false); // agregado
        animator.Play("Idle");
        //animatore.Play("CorazonLatiendo");
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].enabled = false;
        }
        numeroFlecha = 0;
        numeroApretado = 0;

    }

   private void Start() // **agregado para la vida**
    {
        vidaj1Text.text = "" + vidaJ1;
        vidaj2Text.text = "" + vidaJ2;

        Ganador1.SetActive(false);
        Ganador2.SetActive(false);
        ganadorFinal.SetActive(false);
        partidaFinalizada.enabled = false;
        fondoAtras.enabled = false;
        botonVolverAjugar.gameObject.SetActive(false);
        botonVolverAmenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(boton))
       {
           ReproducirAnimacion("Disparo");

           if (player1 == true)
           {
               gameManager.p1Disparo = true;
               gameManager.tiempoP1 = Time.time;        
           }
           else
           {
               gameManager.p2Disparo = true;
               gameManager.tiempoP2 = Time.time;
           }
           gameManager.Comparar();
       }*/
        //DispararFueraDeTiempo();
        if (!noPresionarTecla)
        {
            DispararFueraDeTiempo();
            DetectarBoton();

        }

        vidaj1Text.text = "" + vidaJ1; //**AQUI IGUAL**
        vidaj2Text.text = "" + vidaJ2;

        CompararVida();

    }

    public void ReproducirAnimacion(string nombreAnimacion)
    {
        animator.Play(nombreAnimacion);
    }

    public void ReproduceAnimacion(string nombAnimacion)
    {
        animatore.Play(nombAnimacion);
    }

    public void GenerarNumero()
    {
        numeroFlecha = Random.Range(0, 4);
    }

    public void DetectarBoton()
    {

        if (!enTiempo)
        {
            return;
        }

         puedoPresionarTecla = true;

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaUp))
        {
            numeroApretado = 0;
            CompararNumero();
            //noPresionarTecla = true;
        }

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaD))
        {
            numeroApretado = 1;
            CompararNumero();
            //noPresionarTecla = true;
        }

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaAb))
        {
            numeroApretado = 2;
            CompararNumero();
            //noPresionarTecla = true;
        }

        if (puedoPresionarTecla == true && Input.GetKeyDown(flechaIz))
        {
            numeroApretado = 3;
            CompararNumero();
            //noPresionarTecla = true;
        }
    }

    public void DispararFueraDeTiempo()
    {
        if (!enTiempo && !puedoPresionarTecla)
        {
            if (Input.GetKeyDown(flechaUp)) //animator.SetTrigger("PresionoAntes"); Agregue en animator los make transition en idle y Presiono antes
                                                                                  //a los 2 player y un trigger llamado PresionoAntes.
            {
                print("Error Presiono antes");
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaD)) //animator.SetTrigger("PresionoAntes");
            {
                print("Error Presiono antes");
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaAb)) //animator.SetTrigger("PresionoAntes");
            {
                print("Error Presiono antes");
                SeEquivoco();
            }

            if (Input.GetKeyDown(flechaIz)) //animator.SetTrigger("PresionoAntes");
            {
                print("Error Presiono antes");
                SeEquivoco();
            }
        }

        //SeEquivoco();
    }

    void SeEquivoco()
    {
        //print("Error Presiono antes");
        ReproducirAnimacion("PresionoAntes");
        //noPresionarTecla = true;
    }

    void FlechaEquivocada()
    {
        print("Flecha Equivocada");
        CambiarColor2("red");

    }

    void CompararNumero()
    {
        if (numeroApretado == numeroFlecha)
        {
            print("Correcto"); //Borrar despues
                ReproducirAnimacion("Disparo");
                CambiarColor("green");
                if (player1 == true)
                {
                    gameManager.p1Disparo = true;
                    gameManager.tiempoP1 = Time.time;
                }
                else
                {
                    gameManager.p2Disparo = true;
                    gameManager.tiempoP2 = Time.time;
                }
                gameManager.Comparar();
            Invoke("ColorBase", 3.93f); //agregado
            noPresionarTecla = true; //agregado
           
        }
        else
        {
            FlechaEquivocada();
            ReproducirAnimacion("TeclaEquivocada");
            if (player1 == true)
            {
                gameManager.p1Disparo = false;
                //gameManager.tiempoP1 = Time.time;
            }
            else
            {
                gameManager.p2Disparo = false;
                //gameManager.tiempoP2 = Time.time;
            }
            Invoke("ColorBase", 1f);  //Jugar con esto y con el tiempoDeEspera 
            Invoke("MostrarFlecha", 0.9f); // Cuidado con los valores
        }

    }

    public void MostrarFlecha()
    {
        GenerarNumero();

        for(int i = 0; i < flechas.Length; i++)
        {
            flechas[i].enabled = numeroFlecha == i? true : false;
        }

        enTiempo = true;
    }

    void CambiarColor(string color)
    {
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].color = color == "green" ? Color.green : Color.white;
        }
    }

    void CambiarColor2(string color)
    {
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].color = color == "red" ? Color.red : Color.white;
        }
    }

     void VolverAColorBase(string color)
    {
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].color = color == "white" ? Color.white : Color.white;
        }
    }

    void ColorBase()
    {
        VolverAColorBase("white");
    }

    public void NoAnimacion()
    {
        noPresionarTecla = true;
    }

    public void PerdidaVidaJ2() //**AQUI QUITAR**
    {
        vidaJ2 -= 1;
    }

    public void PerdidaVidaJ1()
    {
        vidaJ1 -= 1;
    }

    public void AparecerMenu()
    {
        botonVolverAjugar.gameObject.SetActive(true);
        botonVolverAmenu.gameObject.SetActive(true);
        partidaFinalizada.enabled = true;
        fondoAtras.enabled = true;
    }

    public void MostrarPrimerGanador()
    {
        Ganador1.SetActive(true);
    }

    public void MostrarSegunGanador()
    {
        Ganador2.SetActive(true);
    }


    public void CompararVida()
    {

        if(vidaJ1 > 0 && vidaJ2 <= 0)
        {
            Invoke("MostrarPrimerGanador", 1f);
            Invoke("SonidoGanadorFinal", 1f);
            ReproduceAnimacion("Corazon Muerte2 ");
            // Hacer visible el gameobject ganador jugador 1
            //Ganador1.SetActive(true);
            // Detener el reseteo o pausar el juego
             //***Listo***
            //Hacer aparecer el menu de partida finalizada
            Invoke("AparecerMenu", 4f);
        }

        if (vidaJ1 <= 0 && vidaJ2 > 0)
        {
            Invoke("MostrarSegunGanador", 1f);
            Invoke("SonidoGanadorFinal", 1f);
            ReproduceAnimacion("Corazon Muerte ");
            // Hacer visible el gameobject ganador jugador 2
            //Ganador2.SetActive(true);
            // Detener el reseteo o pausar el juego
            //***Listo***
            //Hacer aparecer el menu de partida finalizada
            Invoke("AparecerMenu", 4f);
        }
    }

   public void DesaparecerFlechas()
    {
        for (int i = 0; i < flechas.Length; i++)
        {
            flechas[i].enabled = false;
        }
    }

    public void SonidoGanadorFinal()
    {
        ganadorFinal.SetActive(true);
    }
}
