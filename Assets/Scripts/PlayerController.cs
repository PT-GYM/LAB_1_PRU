using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float Destroytime = 5f;
    public Transform muzzleSpawnPosition;

    private void Update()
    {
        playermovement();
        bulletshoot();
    }
    // Update is called once per frame
    void playermovement()
    {
        //player movement
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xPos, yPos, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void bulletshoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            SpawnMissile();
            SpawnMuzzle();
        }
    }

    void SpawnMissile()
    {
        GameObject gym = Instantiate(missile, missileSpawnPosition);
        gym.transform.SetParent(null);
        Destroy(gym, Destroytime);
    }

    void SpawnMuzzle()
    {
        GameObject muzz = Instantiate(GameManager.instance.muzzleFlash, muzzleSpawnPosition);
        muzz.transform.SetParent(null);
        Destroy(muzz, Destroytime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject gy = Instantiate(GameManager.instance.explosionEffect, transform.position, transform.rotation);
            Destroy(gy, 2f);
            Destroy(this.gameObject);
            Debug.Log("Game Over");
        }
    }
}
