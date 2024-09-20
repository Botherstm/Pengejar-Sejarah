using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pertanyaan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Question");
            PlayerManager.gamePause = true;
            Destroy(gameObject);
        }
    }
}
