namespace GMPR_Assignment.assignment1
{
    using System.Collections;
    using UnityEngine;

    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        

         void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ball"))
            {   
                StartCoroutine(BallRespawn(collision.gameObject));
            }
        }

        private IEnumerator BallRespawn(GameObject Ball)
        {
            
            yield return new WaitForSeconds(2);
            Rigidbody2D newBall = Ball.GetComponent<Rigidbody2D>();
            newBall.linearVelocity = Vector2.zero;
            newBall.angularVelocity = 0;
            Ball.transform.position = _spawnPoint.position;
            

        }
    }
}