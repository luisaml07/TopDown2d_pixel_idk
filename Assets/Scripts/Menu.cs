using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject opcionesPanel;
    public void Jugar ()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir ()
    {
        Application.Quit();
    }

    public void AbrirpaneldeOpciones()
    {
       opcionesPanel.SetActive(true);
    }
    public void CerrarpaneldeOpciones()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}