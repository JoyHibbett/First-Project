using UnityEngine;

public class coinScript : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coincounterui.AddScore(1);
            Destroy(gameObject);
        }
    }


}
