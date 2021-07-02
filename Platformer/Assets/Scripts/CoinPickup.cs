using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    private int coinCount = 0;

    [SerializeField] private Text coinCountText;

    [SerializeField] private AudioSource pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            pickupSound.Play();
            coinCount++;
            coinCountText.text = coinCount.ToString();
            Destroy(collision.gameObject);
        }
    }
}
