using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    private void Start()
    {
        {
            GameManager.currentLevelNumber = 1;
        }
    }
    public void Fase1()
    {
        GameManager.currentLevelNumber = 1;
        Fase();
    }
    public void Fase2() 
    {
        GameManager.currentLevelNumber = 2;
        Fase();
    }
    public void Fase3()
    {
        GameManager.currentLevelNumber = 3;
        Fase();
    }
    public void Fase4()
    {
        GameManager.currentLevelNumber = 4;
        Fase();
    }
    public void Fase5()
    {
        GameManager.currentLevelNumber = 5;
        Fase();
    }
    public void Fase6()
    {
        GameManager.currentLevelNumber = 6;
        Fase();
    }
    public void Fase7()
    {
        GameManager.currentLevelNumber = 7;
        Fase();
    }
    public void Fase8()
    {
        GameManager.currentLevelNumber = 8;
        Fase();
    }
    public void Fase9()
    {
        GameManager.currentLevelNumber = 9;
        Fase();
    }
    public void Fase10()
    {
        GameManager.currentLevelNumber = 10;
        Fase();
    }
    public void Select()
    {
        SceneManager.LoadScene("SelectFase", LoadSceneMode.Single);
    }
    public void Return()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
    public void Fase()
    {
        GameManager.currentLevel = "Fase" + GameManager.currentLevelNumber;
        SceneManager.LoadScene("Fase" + GameManager.currentLevelNumber, LoadSceneMode.Single);
    }
    public void Next()
    {
        GameManager.currentLevelNumber++;
        Fase();
    }
}
