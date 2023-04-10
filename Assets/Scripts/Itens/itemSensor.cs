using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class itemSensor : MonoBehaviour
{
    [SerializeField] UnityEvent onSensorEnter;
    [SerializeField] UnityEvent onSensorStay;
    [SerializeField] UnityEvent onSensorExit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        onSensorEnter.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        onSensorStay.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onSensorExit.Invoke();
    }
}
