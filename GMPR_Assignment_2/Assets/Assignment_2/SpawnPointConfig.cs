using UnityEngine;

namespace Assignment_2
{
    

    public class SpawnPointConfig : MonoBehaviour
    {
        [SerializeField] Transform _SpawnPosition;
        [Range(-10f, 10f)][SerializeField] float _xSpawn = 2.281f, _ySpawn = -0.211f;


        private void OnValidate()
        {
            if (_SpawnPosition != null )
            {
                _SpawnPosition.position = new Vector2(_xSpawn, _ySpawn);
            }
        }
    }
}