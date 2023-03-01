using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject playerTrail;
    
    float playerYPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerYPosition = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (!playerTrail.activeInHierarchy)
            {
                playerTrail.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                SwitchPosition();
            }
        }
    }

    void SwitchPosition()
    {
        playerYPosition = -playerYPosition;

        transform.position = new Vector3(transform.position.x, playerYPosition, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GameManager.instance.UpdateLives();
            GameManager.instance.Shake();
        }
    }
}
