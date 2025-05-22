using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    [SerializeField]
    private float _maxTime = 10f;

    [SerializeField]
    private float _highRange = 1f;

    [SerializeField]
    private GameObject _platformPrefab;

    [SerializeField]
    private float _distance = 10f;

    private float timer;

    [SerializeField]
    private Transform _player; // a macska

    private bool _firstPlatformSpawned = false;
    private float _lastPlatformX;



    private void Start()
    {
        _lastPlatformX = _player.position.x;
        SpawnFirstPlatformUnderPlayer();
        _firstPlatformSpawned = true;
    }


    private void Update()
    {
        if (!_firstPlatformSpawned)
        {
            SpawnFirstPlatformUnderPlayer();
            _firstPlatformSpawned = true;
            return;
        }

        if (timer > _maxTime)
        {
            SpawnPlatform();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnFirstPlatformUnderPlayer()
    {
        Vector3 spawnPos = new Vector3(
            _player.position.x,
            _player.position.y - 1f, // vagy állítsd be, hogy mennyivel alá
            _player.position.z
        );

        GameObject newPlatform = Instantiate(_platformPrefab, spawnPos, Quaternion.identity);
        Destroy(newPlatform, 10f);
    }

    private void SpawnPlatform()
    {
        float xOffset = Random.Range(_distance * 1f, _distance * 1.2f); // kis variáció, hogy ne legyen mindig egyforma

        _lastPlatformX += xOffset;

        Vector3 spawnPos = new Vector3(
            _lastPlatformX,
            transform.position.y + Random.Range(-_highRange, +_highRange),
            transform.position.z
        );

        GameObject newPlatform = Instantiate(_platformPrefab, spawnPos, Quaternion.identity);
        Destroy(newPlatform, 40f);
    }


}
