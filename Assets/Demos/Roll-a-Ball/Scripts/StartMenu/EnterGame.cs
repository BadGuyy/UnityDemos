using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Roll-a-Ball");
    }
}
