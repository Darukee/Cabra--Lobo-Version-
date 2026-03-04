using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int bloodLust, numSteps, bloodLustMax;
    public static string currentLevel;
    //int currentLevelNumber;
    public LayerMask wallLayer;
    static GameManager instance;

    /* void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    */

    void Start()
    {
        bloodLust = 0;
        //Fase1(); //temporário
    }
    void Update()
    {
        Reset();
        Fases();
    }
    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
            LoboScript.moveBlock = false;
        }      
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
    void Fases() //Switch case que será utilizado para determinar a fase
    {
        switch (currentLevel)
        {
            case "Fase1":
                numSteps = 10;
                bloodLustMax = 1;
                break;

            case "Fase2":
                numSteps = 5;
                bloodLustMax = 1;
                break;
        }
    }
}
