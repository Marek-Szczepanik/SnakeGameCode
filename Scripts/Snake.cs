using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Snake : MonoBehaviour
{
    [SerializeField] int InitialBodySize = 3;
    [SerializeField] int RotationSpeed = 0;
    [SerializeField] Transform segmentPrefab;
    [SerializeField] TextMeshProUGUI scoreText;
    private Vector2 _direction = Vector2.up;
    AudioSource moveSound;

    private List<Transform> _segments;
    private void Awake() {
        moveSound = this.GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
        {
            Database.Dbscore = 0;
            Database.Dbtimer = 0;
        }
    }
    private void Start(){
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        for (int i = 0; i < InitialBodySize; i++)
        {
            Grow();
        }
    }
    private void Update() {
        HandleMovement();
        Rotatehead();
    }
    private void HandleMovement(){
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
            moveSound.Play();
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
            moveSound.Play();
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
            moveSound.Play();
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
            moveSound.Play();
        }
    }

    void FixedUpdate()
    {
        for (int i = _segments.Count -1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + _direction.x,
            Mathf.Round(transform.position.y) + _direction.y,
            0
        );
    }
    private void Rotatehead(){
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, _direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotation,RotationSpeed * Time.deltaTime); 
    }
    private void Grow(){
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count -1].position;
        _segments.Add(segment);
    }

    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food"){
            Grow();
            //scoreManager.IncreaseScore();
            //scoreText.text = scoreManager.GetScore().ToString();
            Database.Dbscore++;
            scoreText.text = Database.Dbscore.ToString();
        }
        else if(other.tag == "Obstacle"){
            SceneManager.LoadScene("EndScene");
        }
    }

}
