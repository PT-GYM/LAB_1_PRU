using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float enemyDestroyTime = 5f;

    [Header("Partice Effects")]
    public GameObject explosionEffect;
    public GameObject muzzleFlash;

    [Header("Panels")]
    public GameObject StartMenu;
    public GameObject PauseMenu;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartMenu.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGameButton(true);
        }
    }

    void InstantiateEnemy()
    {
        Vector3 enemypros = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 6f);
        GameObject enemy = Instantiate(enemyPrefab, enemypros, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy, enemyDestroyTime);
    }
    public void StartGameButton()
    {
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseGameButton(bool isPaused)
    {
        if (isPaused == true)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
