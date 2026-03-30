using UnityEngine;


namespace assignment_3
{
    public class Alien : MonoBehaviour
    {
        Fleet leaderScript;
        [SerializeField] private float _projectileSpeed = 5, _projectileSpinVelocity = -2000;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private int _upperRandomFiringRange;
        float xDirection, yDirection;
        void Awake()
        {
            leaderScript = transform.parent.GetComponent<Fleet>();
            
        }
        private void Update()
        {
            int rando = Random.Range(1, _upperRandomFiringRange);
            if (rando == 1)
            {
                Vector3 firingPosition = transform.GetChild(0).position;
                GameObject theProjectile = Instantiate(_projectilePrefab, firingPosition, transform.rotation);
                ProjectileAlien projectileScript = theProjectile.GetComponent<ProjectileAlien>();
                projectileScript.Speed = _projectileSpeed;
                projectileScript.Direction = -transform.up;
                projectileScript.SpinVelocity = _projectileSpinVelocity;
            }
        }
        void OnTriggerEnter2D(Collider2D collision)
         {

            if (collision.transform.tag.Equals("Wall"))
            {
                xDirection = leaderScript.Direction.x;
                yDirection = leaderScript.Direction.y;
                leaderScript.Direction = new Vector2(-xDirection, yDirection);
                leaderScript.ShiftDown();
            }

         }
       
    }
}
