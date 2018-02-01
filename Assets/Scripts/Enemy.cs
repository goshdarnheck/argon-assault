using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;

	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        GameObject shipPrefab = gameObject.transform.GetChild(0).gameObject;
        Renderer shipPrefabRenderer = shipPrefab.GetComponent<Renderer>();
        boxCollider.size = new Vector3(shipPrefabRenderer.bounds.size.x, shipPrefabRenderer.bounds.size.y, shipPrefabRenderer.bounds.size.z);
    }

    private void OnParticleCollision(GameObject other) {
        // print("Particles collied with enemy" + gameObject.name);

        Instantiate(deathFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
