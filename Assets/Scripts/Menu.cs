using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Jugar ()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir ()
    {
        Application.Quit();
    }
}