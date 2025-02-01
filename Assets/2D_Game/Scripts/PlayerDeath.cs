using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject deathObj;

    private void Update()
    {
        float xVal = transform.position.x;
        deathObj.transform.position = new Vector3(xVal, deathObj.transform.position.y, 0);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
