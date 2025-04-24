using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public Transform spawnPoint;

    void Start()
    {
        if (characterPrefab != null && spawnPoint != null)
        {
            Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("CharacterPrefab or SpawnPoint not assigned in CharacterSpawner.");
        }
    }
}
