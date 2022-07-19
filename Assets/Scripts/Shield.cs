using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float amplitude = 2f;
    private Vector3 startPos;
    [SerializeField] GameObject player;
    PlayerController playerController;

    void Start()
    {
        startPos = transform.position;
        playerController = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        playerController.shieldActive = true;
        playerController.isInvincible = true;
    }

    void Update()
    {
        transform.position = startPos + amplitude * new Vector3(0f, Mathf.Sin(Time.time), 0f);
    }
}
