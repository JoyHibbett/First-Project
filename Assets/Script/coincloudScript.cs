using UnityEngine;

public class coincloudScript : MonoBehaviour
{
    //variables
    public GameObject coinPrefab;
    bool madeCoin;

    void Start()
    {
        madeCoin = false;
        
    }

    void Update()
    {
    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && madeCoin == false )
        {
            madeCoin=true;

            GameObject coin;
            coin = Instantiate(coinPrefab, transform.position, transform.rotation);

            coin.transform.position = new Vector3(transform.position.x, transform.position.y+5, transform.position.z);
        }
    }

}
