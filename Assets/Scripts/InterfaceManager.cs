using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public void Fase1() //funcionando agora apenas pois não há sistema de fases ainda 
    {
        SceneManager.LoadScene("Fase1", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase1"; //temp - será transferido para o sistema de seleção de fases, usando o "currentLevelNumber" para passar de uma fase a outra com o "´next"
        //GameManager.currentLevelNumber = 1;
    }
    public void Fase2() 
    {
        SceneManager.LoadScene("Fase2", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase2";
    }
    public void Fase3()
    {
        SceneManager.LoadScene("Fase3", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase3";
    }
    public void Fase4()
    {
        SceneManager.LoadScene("Fase4", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase4";
    }
    public void Fase5()
    {
        SceneManager.LoadScene("Fase5", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase5";
    }
    public void Fase6()
    {
        SceneManager.LoadScene("Fase6", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase6";
    }
    public void Fase7()
    {
        SceneManager.LoadScene("Fase7", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase7";
    }
    public void Fase8()
    {
        SceneManager.LoadScene("Fase8", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase8";
    }
    public void Fase9()
    {
        SceneManager.LoadScene("Fase9", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase9";
    }
    public void Fase10()
    {
        SceneManager.LoadScene("Fase10", LoadSceneMode.Single);
        GameManager.currentLevel = "Fase10";
    }
    public void Select()
    {
        SceneManager.LoadScene("SelectFase", LoadSceneMode.Single);
    }

}
