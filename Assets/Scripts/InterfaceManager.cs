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
    }
}
