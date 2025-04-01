using UnityEngine;


public  class AddPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEvent.addPlayer?.Invoke(transform.position);
            this.gameObject.SetActive(false);
        }
    }
}