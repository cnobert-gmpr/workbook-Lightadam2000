using UnityEngine;

namespace assignment_3
{
    public class Fleet : MonoBehaviour
    {
        [SerializeField] private float _speed = 2;
        [SerializeField] private Vector2 _direction = new Vector2(-1, 0);
        float fleetMovement = -0.75f;

        internal Vector2 Direction 
       { 
            get => _direction;
            set => _direction = value;
       }

        // Update is called once per frame
        private void Awake()
        {
           
        }
        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime);
            
        }
        public void ShiftDown()
        {
            
            transform.position += new Vector3(0, fleetMovement, 0);
            if (transform.position.y <= 2) 
            {
                fleetMovement = 0.75f;
            }
            else if (transform.position.y >= 5.8)
            {
                fleetMovement = -0.75f;
            }
        }

    }
}
