using System.Collections;
using UnityEngine;

namespace Assignment_2
{
    

    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        public Flipper[] _flippers;
        public Plunger _plunger;

         void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ball"))
            {   

                StartCoroutine(BallRespawn(collision.gameObject));
            }
        }

        private IEnumerator BallRespawn(GameObject Ball)
        {   
            foreach (Flipper disable in _flippers) 
                    disable.Deactivate();
            
            _plunger.Decactivate();

            yield return new WaitForSeconds(2);

            foreach (Flipper enable in _flippers)
                enable.Activate();

            _plunger.Activate();
            Rigidbody2D newBall = Ball.GetComponent<Rigidbody2D>();
            
            newBall.linearVelocity = Vector2.zero;
            newBall.angularVelocity = 0;
            //_flippers.Activate();
            Ball.transform.position = _spawnPoint.position;
            

        }
    }
}