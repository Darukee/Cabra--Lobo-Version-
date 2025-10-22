using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int bloodLust, numSteps, bloodLustMax;
    string currentLevel;
    //int currentLevelNumber;
    public LayerMask wallLayer;

    void Start()
    {
        bloodLust = 0;
        Fase1(); //temporário
    }
    void Update()
    {
        Reset();
    }
    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
            LoboScript.moveBlock = false;
        }      
    }
    public void Fase1() //funcionando agora apenas pois não há sistema de fases ainda 
    {
        //SceneManager.LoadScene("Fase1", LoadSceneMode.Single);
        numSteps = 10;
        bloodLustMax = 1;
        currentLevel = "Fase1"; //temp - será transferido para o sistema de seleção de fases, usando o "currentLevelNumber" para passar de uma fase a outra com o "´next"
    }
    public static void GameOver() //todos os tipos de game over diferentes que o jogador pode conseguir, possivelmente virá a ser um switch case
    {
        Debug.Log("Game Over");
    }
    public static void Win() //menu que aparece quando o jogador ganha e a situação para isso acontecer
    {
        if (bloodLust == bloodLustMax)
        {
            LoboScript.moveBlock = true;
            Debug.Log("Você ganhou!");
        }
    }

    void Fases() //Switch case que será utilizado para determinar 
    {
        switch (currentLevel)
        {
            case "Fase1":
                numSteps = 10;
                bloodLustMax = 1;
                break;
        }
    }
}
