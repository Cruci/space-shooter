using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameObject gameControllerObject;
    private GameController gameController;

    public int scoreValue;

    private void Start()
    {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (!gameControllerObject)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (explosion)
        {
            Instantiate(explosion, transform.position, transform.rotation);

        }

        if (other.CompareTag("Player")) 
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
