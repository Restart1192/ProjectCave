using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] private GameObject Level;

    private List<string> text;
    private int keyOpen;
    public bool isEnd = false;

    [SerializeField] public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        startLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyOpen == 3)
        {
            door.transform.position -= new Vector3(0,4,0);
            keyOpen = 0;
        }
    }

    public void startLevel()
    {
        keyOpen = 0;
    }

    public void endLevel()
    {
        isEnd = true;
        //Level.SetActive(false);
    }

    public void getKey()
    {
        keyOpen += 1;
    }
}
