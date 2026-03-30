using UnityEngine;

namespace assignment_3
{
    public class Barrier : MonoBehaviour
    {
        [SerializeField] private float _speed = 1;
        [SerializeField] private Vector2 _direction = new Vector2(-1, 0);
        

        internal Vector2 Direction
        {
            get => _direction;
            set => _direction = value;
        }
        
        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime);

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag.Equals("Wall"))
            {
                _direction.x *= -1f; 
            }
        }
    }
}
