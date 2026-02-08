namespace GMPR_Assignment.assignment1 

{
    using UnityEngine;

    public class SpawnPointConfig : MonoBehaviour
    {
        [SerializeField] Transform _SpawnPosition;
        [Range(-10f, 10f)][SerializeField] float _xSpawn = 2 , _ySpawn = 3;


        private void OnValidate()
        {
            if (_SpawnPosition != null )
            {
                _SpawnPosition.position = new Vector2(_xSpawn, _ySpawn);
            }
        }
    }
}