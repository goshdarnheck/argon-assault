using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

	void Start () {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
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
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
