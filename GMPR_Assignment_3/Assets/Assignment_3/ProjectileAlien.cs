using UnityEngine;

namespace assignment_3
{
    public class ProjectileAlien : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionTransform;
        private float _speed = 10, _spinVelocity = 0;
        private Vector2 _direction = Vector2.up;

        internal Vector2 Direction { set => _direction = value; }
        internal float Speed { set => _speed = value; }
        internal float SpinVelocity { set => _spinVelocity = value; }
        // Update is called once per frame
        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
            transform.Rotate(new Vector3(0, 0, _spinVelocity * Time.deltaTime), Space.World);
        }
        void OnTriggerEnter2D(Collider2D collider)
        {

            if (collider.transform.tag.Equals("DeathZone"))
            {
                Destroy(gameObject);
            }

            if (collider.transform.tag.Equals("Ship"))
            {
                Instantiate(_explosionTransform, collider.transform.position, transform.rotation);
                Destroy(collider.gameObject);
            }

            if (collider.transform.tag.Equals("Barrier"))
            {
                Instantiate(_explosionTransform, collider.transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
    }
}

