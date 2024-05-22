using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Counter;
    private float time = 20;
    public GameObject options;
    public GameObject gameOptions;

    public int count = 0;

    private void Start()
    {
        gameOptions.SetActive(false);
        options.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(count);
        time = time - Time.deltaTime;

        Counter.text = "Time: " + time.ToString("F0");

        if (count == 10)
        {
            SceneManager.LoadScene("Victoria");
        }

        if (time <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }
    public void AppearOptions()
    {
        Time.timeScale = 0;
        options.SetActive(true);
    }

    public void DissappearOptions()
    {
        Time.timeScale = 1;
        options.SetActive(false);
    }

    public void Load3D()
    {
        SceneManager.LoadScene("Game3D");
        Time.timeScale = 1;
    }
    public void Return()
    {
        SceneManager.LoadScene("Menú");
        Time.timeScale = 1;
    }

    public void AppearGameOption()
    {
        gameOptions.SetActive(true);
    }

    public void Load2D()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game2D");
    }

}
