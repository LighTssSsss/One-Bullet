using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPartidaFinalizada : MonoBehaviour
{
    public void VolveraJugar()
    {
        Invoke("CargarEscena", 0.8f);
        //SceneManager.LoadScene("Duelos");
    }

    public void IraMenu()
    {
        Invoke("VolverAlMenu",0.8f);
        //SceneManager.LoadScene("Menu");
    }

    public void CargarEscena()
    {
        SceneManager.LoadScene("Duelos");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
