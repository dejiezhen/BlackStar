using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImg;
    public static int lives = 3;
    public GameObject musicManager;
    private GameObject gmObject;
    private GameManager gm;
    [SerializeField]
    private AudioClip deathSound;
    private AudioSource audioSource;
    private AudioSource backgroundMusic;
    [SerializeField] RectTransform fader;



    void Awake()
    {

        if ((instance != null) && (instance != this))
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            if (lives > 0)
            {
                _livesImg.sprite = _livesSprites[lives - 1];
            }

        }


    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void UpdateLives(int currentLives)
    {
        instance.LivesChange(currentLives);
    }

    //Changes the lives
    private void LivesChange(int lives)
    {
        Debug.Log("deathhhhh");
        if (lives <= 0)
        {
            Lose();
        }
        else if (_livesSprites.Length > lives - 1)
        {
            Debug.Log("triggered");
            _livesImg.sprite = _livesSprites[lives - 1];
        }
    }

    private void Lose()
    {
        musicManager = GameObject.Find("MusicManager");
        backgroundMusic = musicManager.GetComponent<AudioSource>();
        backgroundMusic.Stop();
        audioSource.PlayOneShot(deathSound);
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 2f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            gmObject = GameObject.Find("SceneGameManager");
            gm = gmObject.GetComponent<GameManager>();
            Debug.Log(gm.overallScore);
            SceneManager.LoadScene("GameOver");
        });
    }
}
