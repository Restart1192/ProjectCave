using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Player.position - oldPosition;
        oldPosition = Player.position;
    }
}
