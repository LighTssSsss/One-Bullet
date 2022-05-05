using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonido : MonoBehaviour
{
    public GameObject sonidoSeleccionar;
    public GameObject sonidoPresionar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonSonidoSeleccionar()
    {
        Instantiate(sonidoSeleccionar);
    }

    public void BotonSonidoPresionar()
    {
        Instantiate(sonidoPresionar);
    }
}
