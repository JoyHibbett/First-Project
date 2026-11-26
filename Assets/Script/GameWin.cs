using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GameWin : MonoBehaviour
{
    //variables

    Image image;

    public static bool playerWon;
    void Start()
    {
        playerWon = false;
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.enabled = playerWon;
    }
}