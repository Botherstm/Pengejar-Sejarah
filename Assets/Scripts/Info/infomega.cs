using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infomega : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void Update()
    {
        transform.Rotate( 0,50 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.infomega = true;
            PengolahSoal.soalMega = true;
            Destroy(gameObject);
        }
    }
}
