namespace GMPR_Assignment.assignment1
{
    using System.Collections;
    using UnityEngine;

    public class Freeze : MonoBehaviour
    {
        
        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Ball"))
            {
                StartCoroutine(FreezeBall(collision));
            }
        }

        IEnumerator FreezeBall(Collider2D Ball)
        {

            Rigidbody2D freezeBall = Ball.GetComponent<Rigidbody2D>();
            freezeBall.linearVelocity = Vector2.zero;
            freezeBall.gravityScale = 0;

            yield return new WaitForSeconds(2);

            freezeBall.gravityScale = 1;
            

            
        }
    }
}