using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject _pickupEffect;
    [SerializeField] private int _typeIndex;

    private void Pickup() {
        CollectibleList.Instance.UpdateList(_typeIndex);

        _pickupEffect = Instantiate(_pickupEffect, transform.position, transform.rotation);
        StartCoroutine(DestroyDelay());
    }

    private IEnumerator DestroyDelay() {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(_pickupEffect);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            Pickup();
    }
}
