using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    public void LoadGame(){
        clickSound.Play();
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame(){
        clickSound.Play();
        Application.Quit();
    }
}
