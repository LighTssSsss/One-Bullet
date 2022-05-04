using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPartidaFinalizada : MonoBehaviour
{
    public void VolveraJugar()
    {
        SceneManager.LoadScene("Duelos");
    }

    public void IraMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
