using UnityEngine;

namespace assignment_3
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private GameObject _alien;
        void Awake()
        {
            if (_alien != null)
            {
                Instantiate(_alien, transform.position, transform.rotation);
            }
            else
            {
                Debug.LogError("You forgot to drag the Alien prefab into the Spawn script on " + gameObject.name);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
