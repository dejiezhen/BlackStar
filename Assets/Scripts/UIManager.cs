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
    [SerializeField]
    private AudioClip deathSound;
    private AudioSource audioSource;
    private AudioSource backgroundMusic;
    [SerializeField]
    private RectTransform fader;
    [SerializeField]
    private GameManager gm;

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

    private void LivesChange(int lives)
    {
        if (lives <= 0)
        {
            Lose();
        }
        else if (_livesSprites.Length > lives - 1)
        {
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
            gm.playing = false;
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Tutorial")
            {
                SceneManager.LoadScene("MainMenu");
            } else
            {
                SceneManager.LoadScene("GameOver");

            }
        });
    }
}
