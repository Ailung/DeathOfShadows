using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Saliste con exito");
        Application.Quit();
    }

    public void Creditos()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("CreditsScene");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
