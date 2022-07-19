using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEnemyMace : MonoBehaviour
{
    [SerializeField] private float amplitude = 2f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + amplitude * new Vector3(0f, Mathf.Tan(Time.time), 0f);
    }
}