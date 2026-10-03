using UnityEngine;

public class RelicPickup : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        GameManager.Instance.CollectRelic(this);
        Destroy(gameObject);
    }
}
