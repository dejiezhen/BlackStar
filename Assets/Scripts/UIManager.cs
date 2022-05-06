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

    private void Update()
    {
        Debug.Log(lives);
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
        SceneManager.LoadScene("GameOver");
    }
}
