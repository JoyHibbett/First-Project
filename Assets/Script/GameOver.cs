using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GameOver : MonoBehaviour
{
    //variables

    Image image;

    public static bool playerDied;
    void Start()
    {
        playerDied = false;
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.enabled = playerDied;

        if (playerDied == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            coincounterui.score = 0;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
/*
    public void PlayerDead;
    {
     gameObject.SetActive(true)
    Instantiate(gameoverscreen, transform.position, transform.rotation)
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    // set the position close to the player
    rb.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }
}
*/
