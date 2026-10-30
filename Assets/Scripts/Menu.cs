using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelOpciones;
     void Start()
    {
        // Aseguro que los paneles empiecen ocultos
        panelCreditos.SetActive(false);
        panelOpciones.SetActive(false);
    }
    public void Jugar ()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir ()
    {
        Application.Quit();
    }


    public void AbrirCreditos()  
    { 
        panelCreditos.SetActive(true); 
    }
    public void CerrarCreditos() 
    { 
        panelCreditos.SetActive(false); 
    }

    public void AbrirOpciones()  
    { 
        panelOpciones.SetActive(true); 
    }
    public void CerrarOpciones() 
    { 
        panelOpciones.SetActive(false); 
    }

}