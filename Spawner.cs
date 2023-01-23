using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Spawner : MonoBehaviour
{
    public Transform prefab;
    public Vector3 minimumScale = Vector3.one;
    public Vector3 maximumScale = Vector3.one;
    public bool randomRotation = false;
    public float radiusToSpawnIn = 3f;
    [Range(0.5f,4f)]
    public float timeBetweenSpawns = 2f;
    public List<AudioClip> audioOnSpawn = new List<AudioClip> ();
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {   
        audioSource = GetComponent<AudioSource> ();
        InvokeRepeating("Spawn", timeBetweenSpawns, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        Vector3 position = (transform.position + Random.insideUnitSphere) * radiusToSpawnIn;
        Quaternion rotation = Quaternion.identity;
        if (randomRotation)
        {
            rotation = Random.rotation;
        }
        Transform instance = Instantiate(prefab, position, rotation);

        Vector3 scale = new Vector3(Random.Range(minimumScale.x, maximumScale.x),
                                    Random.Range(minimumScale.y, maximumScale.y),
                                    Random.Range(minimumScale.z, maximumScale.z));
        instance.localScale = scale;
        audioSource.clip = audioOnSpawn[Random.Range(0, audioOnSpawn.Count)];
    }
}
