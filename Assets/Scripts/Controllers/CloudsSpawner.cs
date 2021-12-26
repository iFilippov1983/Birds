using System.Collections.Generic;
using UnityEngine;

namespace Birds
{
    class CloudsSpawner
    {
        private Transform _cloudsSpawnField;
        private Transform[] _points;
        private GameObject _cloudPrefab;
        private List<GameObject> _clouds;

        private float minMultiplyer = 1.5f;
        private float maxMultiplyer = 6f;

        public CloudsSpawner(Transform cloudsSpawnField, GameObject cloudsPrefabs)
        {
            _cloudsSpawnField = cloudsSpawnField;
            _cloudPrefab = cloudsPrefabs;
            _points = _cloudsSpawnField.GetComponentsInChildren<Transform>();

            _clouds = new List<GameObject>();
        }

        public List<GameObject> Clouds => _clouds;

        public void SpawnClouds()
        {
            GameObject parent = new GameObject();
            parent.name = "Clouds";

            for(int index = 1; index < _points.Length; index++)
            {
                var point = _points[index];
                var position = point.transform.position;

                var cloud = Object.Instantiate(_cloudPrefab, position, Quaternion.identity);

                cloud.transform.localScale *= Random.Range(minMultiplyer, maxMultiplyer);
                cloud.transform.SetParent(parent.transform);

                _clouds.Add(cloud);
            }
        }
    }
}
