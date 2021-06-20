using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public GameObject objectToDestroy;
    public float lifetime;

    private void Start()
    {
        Destroy(objectToDestroy, lifetime);
    }
}
