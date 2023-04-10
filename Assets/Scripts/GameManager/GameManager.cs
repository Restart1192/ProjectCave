using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject main_camera;
    [SerializeField] private Level1 lv1;
    [SerializeField] private GameObject lv1_Object;

    [SerializeField] private int life;
    [SerializeField] private GameObject textDisplayLife;
    [SerializeField] private TextMeshProUGUI textMeshProLife;

    //Panel Game Over
    [SerializeField] private GameObject panelGameEnd;
    [SerializeField] private TextMeshProUGUI textGameEnd;
    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkConditionEndGame())
        {
            endGame();
        }

        textMeshProLife.text = ""+life;
    }


    //Controlo de Jogo
    public void startGame()
    {
        lv1.startLevel();
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

    public void levelPass()
    {
        lv1_Object.SetActive(false);
        textDisplayLife.SetActive(false);
        main_camera.SetActive(true);
        panelGameEnd.SetActive(true);
        textGameEnd.text = "Level Complete!";
    }

    public void endGame()
    {
        lv1_Object.SetActive(false);
        textDisplayLife.SetActive(false);
        main_camera.SetActive(true);
        panelGameEnd.SetActive(true);
        textGameEnd.text = "GameOver";
    }

    //Controlo de vida
    public int getLife()
    {
        return life;
    }

    public void removeLife()
    {
        life--;
    }

    public void setLife(int vida)
    {
        life = vida;
    }

}
