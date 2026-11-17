using UnityEngine;

public class coincloudScript : MonoBehaviour
{
    //variables
    public GameObject coinPrefab;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject coin;
            coin = Instantiate(coinPrefab, transform.position, transform.rotation);

            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();

            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2500, transform.position.z + 1);
        }
    }
}
