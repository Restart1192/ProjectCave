using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class itemConfig : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] UnityEvent onEnterAction;

    private bool isAction;

    // Start is called before the first frame update
    void Start()
    {
        isAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMessage()
    {
        if (isAction)
        {
            textMeshPro.text = text;
            textDisplay.SetActive(true);
        }
    }

    public void pressAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onEnterAction.Invoke();
            textDisplay.SetActive(false);
            isAction = false;
        }
    }

    public void turnOffMessage()
    {
        textDisplay.SetActive(false);
    }



}
