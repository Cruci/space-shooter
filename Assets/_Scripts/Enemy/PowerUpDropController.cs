using UnityEngine;

public class PowerUpDropController : MonoBehaviour
{
    public GameObject powerUp;
    public float dropPercentage = 0.3f;

    private float randomValue;

    public void DropPowerUp()
    {
        randomValue = Random.value;

        if (randomValue < dropPercentage)
        {
            Instantiate(powerUp, this.transform.position, this.transform.rotation);
        }
    }
}
