namespace GMPR_Assignment.assignment1
{
    using UnityEngine;

    public class Portal : MonoBehaviour
    {
        [SerializeField] Transform _portal;
        [SerializeField] Rigidbody2D _ball;

         void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Ball"))
            {

               collision.transform.position = _portal.position;
               Rigidbody2D _ball = collision.GetComponent<Rigidbody2D>();
                _ball.linearVelocity = Vector3.zero;
                _ball.angularVelocity = 0;
               
            } 
        }
    }
}