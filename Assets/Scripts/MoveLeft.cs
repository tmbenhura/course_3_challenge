using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float leftBound = -15f;
    public float moveSpeed = 1f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
