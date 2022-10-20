using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] AudioSource clickSound;
    private void Start() {
        score.text = Database.Dbscore.ToString();
        if (Database.Dbscore >= Database.DbmaxScore)
        {
            Database.DbmaxScore = Database.Dbscore;
        }
        highScore.text ="Your best score: " + Database.DbmaxScore;
    }
        public void LoadGame(){
            clickSound.Play();
            SceneManager.LoadScene("GameScene");
    }
    public void ExitGame(){
        clickSound.Play();
        Application.Quit();
            }
}
