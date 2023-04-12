using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Canvas
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject game;

    //Niveis
    [SerializeField] private GameObject niveis;
    private int nivel = 1;

    //N1
    [SerializeField] private GameObject lv1_Object;
    [SerializeField] private Level1 lv1;

    //N2
    [SerializeField] private GameObject lv2_Object;
    [SerializeField] private Level1 lv2;

    //N3
    [SerializeField] private GameObject lv3_Object;
    [SerializeField] private Level1 lv3;

    //N4
    [SerializeField] private GameObject lv4_Object;
    [SerializeField] private Level1 lv4;

    //Cameras
    [SerializeField] private GameObject main_camera;

    //Vida
    [SerializeField] private int life;
    [SerializeField] private GameObject textDisplayLife;
    [SerializeField] private TextMeshProUGUI textMeshProLife;

    //Panel Game Over
    [SerializeField] private GameObject panelGameEnd;
    [SerializeField] private TextMeshProUGUI textGameEnd;


    void Start()
    {
        //startGame();
    }

    void Update()
    {
        if (checkConditionEndGame())
        {
            endGame();
        }
    }

    //Iniciar o Jogo
    public void startGame()
    {
        //Desligar o menu
        menu.SetActive(false);

        //Ativar o UI Game
        game.SetActive(true);

        //Ativar o primeiro nivel
        niveis.SetActive(true);
        lv1_Object.SetActive(true);
        lv1.startLevel();

        //Set Life
        textMeshProLife.text = "" + life;
    }

    //Terminar o Jogo 
    public void endGame()
    {
        lv1_Object.SetActive(false);
        textDisplayLife.SetActive(false);
        main_camera.SetActive(true);
        panelGameEnd.SetActive(true);
        textGameEnd.text = "GameOver";
    }

    //Fechar o Jogo
    public void exitGame()
    {
        Application.Quit();
    }

    private bool checkConditionEndGame()
    {
        if(life == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Alterar o nivel
    public void levelPass()
    {
        if(nivel == 1)
        {
            lv1_Object.SetActive(false);
            lv2_Object.SetActive(true);
            nivel = 2;

        }else if(nivel == 2)
        {
            lv2_Object.SetActive(false);
            lv3_Object.SetActive(true);
        }
        else if (nivel == 3)
        {
            lv3_Object.SetActive(false);
            lv4_Object.SetActive(true);
        }
        else if (nivel == 4)
        {
            lv4_Object.SetActive(false);
            textDisplayLife.SetActive(false);
            main_camera.SetActive(true);
            panelGameEnd.SetActive(true);
            textGameEnd.text = "Level Complete!";
        }

    }

    //Controlo de vida
    public int getLife()
    {
        return life;
    }

    public void removeLife()
    {
        life--;
        textMeshProLife.text = "" + life;
    }

    public void setLife(int vida)
    {
        life = vida;
        textMeshProLife.text = "" + life;
    }

}
