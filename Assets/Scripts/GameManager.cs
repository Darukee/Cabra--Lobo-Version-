using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class GameManager : MonoBehaviour
{
    //Game related
    public static int bloodLust, numSteps, bloodLustMax, currentLevelNumber;
    public TextMeshProUGUI textSteps, textBlood;
    public static string currentLevel;
    public LayerMask wallLayer;
    public GameObject gameOver, winPanel;

    //Cabra related
    public static bool moveBlock; //controla se o jogador pode ou não se mover
    public static float moveDistance = 2.55f, checkRadius = 0.05f;

    //Audio
    [Header("AudioSource")]
    [SerializeField] AudioSource audioSource;
    [Header("AudioClip")]
    [SerializeField] AudioClip steps, error;

    void Start()
    {
        bloodLust = 0;
        moveBlock = false;
        Fases();
        textSteps.text = "" + numSteps;
        gameOver.SetActive(false);
        winPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !moveBlock)
        {
            Reset();
        }
        
        Interface();
        WinVerifier();

        if (!moveBlock)
        {
            Move();
        }
    }
    public void Reset()
    {
            SceneManager.LoadScene("Fase" + currentLevelNumber, LoadSceneMode.Single);
            moveBlock = false;
        
    }
    public void GameOver() //todos os tipos de game over diferentes que o jogador pode conseguir, possivelmente virá a ser um switch case
    {
        gameOver.SetActive(true);

    }
    public void Win() //menu que aparece quando o jogador ganha e a situação para isso acontecer
    {
        if (bloodLust == bloodLustMax)
        {
            moveBlock = true;
            winPanel.SetActive(true);
        }
    }

    void Fases() //Switch case que será utilizado para determinar a fase
    {
        switch (currentLevel)
        {
            case "Fase1":
                numSteps = 8;
                bloodLustMax = 1;
                break;

            case "Fase2":
                numSteps = 5;
                bloodLustMax = 1;
                break;
        }
    }
    void TryMove(Vector2 direction) //ações que ocorrem quando o personagem tenta se mover
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + direction * moveDistance;

        Collider2D hit = Physics2D.OverlapCircle(targetPos, checkRadius, wallLayer); //esse código checa se há paredes por perto e impede que o personagem se mova em direção a uma

        if (hit == null) //caso não haja parede, o personagem se move
        {
            transform.position = targetPos;
            numSteps--;
            audioSource.clip = steps;
            audioSource.Play();
        }
        else //caso haja parede, o número de passos desce mas o personagem não se move
        {
            numSteps--;
            audioSource.clip = error;
            audioSource.Play();
        }

        if (numSteps <= 0 && !moveBlock) //se acabarem o número de passos, o jogador dá game over
        {
            numSteps = 0;
            textSteps.text = "" + numSteps;
            GameOver();
            moveBlock = true;
        }
        else
        {
            //Debug.Log("Número de passos: " + GameManager.numSteps); //atualiza o número de passos na interface
            textSteps.text = "" + numSteps;
        }
    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            TryMove(Vector2.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            TryMove(Vector2.down);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            TryMove(Vector2.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            TryMove(Vector2.right);
    }

    void Interface()
    {
        textBlood.text = bloodLust + "/" + bloodLustMax;
    }

    void WinVerifier()
    {
        if (bloodLust != bloodLustMax)
        {
            if (AnimalScript.deadAnimal)
            {
                bloodLust++;
                AnimalScript.deadAnimal = true;
                if (bloodLust == bloodLustMax)
                {
                    Win();
                }
            }
        }

        
    }

    /*public static void BloodUpdate()
    {
        //Debug.Log("Animais Mortos: " + bloodLust); //alterar na interface
        textBlood.text = "Animais mortos: " + bloodLust;
        if (bloodLust == bloodLustMax)
        {
            Win();
        }
    }
    */
}
