using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Game related
    public static int bloodLust, numSteps, bloodLustMax, currentLevelNumber;
    public TextMeshProUGUI textSteps, textBlood;
    public static string currentLevel;
    public LayerMask wallLayer;
    //public GameObject Lobo;
    //static GameManager instance;

    //Cabra related
    public static bool moveBlock; //controla se o jogador pode ou não se mover
    public static float moveDistance = 2.55f, checkRadius = 0.05f;

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
        Fases();
        textSteps.text = "" + numSteps;
    }
    void Update()
    {
        Reset();
        Interface();

        if (!moveBlock)
        {
            Move();
        }
    }
    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
            moveBlock = false;
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
            moveBlock = true;
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
    void TryMove(Vector2 direction) //ações que ocorrem quando o personagem tenta se mover
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + direction * moveDistance;

        Collider2D hit = Physics2D.OverlapCircle(targetPos, checkRadius, wallLayer); //esse código checa se há paredes por perto e impede que o personagem se mova em direção a uma

        if (hit == null) //caso não haja parede, o personagem se move
        {
            transform.position = targetPos;
            numSteps--;
        }
        else //caso haja parede, o número de passos desce mas o personagem não se move
        {
            numSteps--;
        }

        if (numSteps <= 0) //se acabarem o número de passos, o jogador dá game over
        {
            GameOver();
            numSteps = 0;
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
