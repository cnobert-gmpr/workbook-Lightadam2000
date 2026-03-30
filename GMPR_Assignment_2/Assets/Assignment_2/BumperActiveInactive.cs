using UnityEngine;
using System.Collections;

namespace Assignment_2
{
    

    public class BumperActiveInactive : MonoBehaviour
    {
        //Ran out of time and was drained didn't get this to work.
        [SerializeField] private float _bumperForce = 150, _litDuration = 0.2f;
        [SerializeField] private Color _litColour = Color.yellow;
        [SerializeField] private bool _bumperActive1 = true;
        [SerializeField] private bool _bumperActive2 = true;
        
        private bool _isLit = false;
        
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider;
        private Color _originalColour;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();
            _originalColour = _spriteRenderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
           
                Collision(collision);
                

        }//End of OnCollision
        private IEnumerator LightUp()
        {
            _isLit = true;
            _spriteRenderer.color = _litColour;
            yield return new WaitForSeconds(_litDuration);
            _spriteRenderer.color = Color.clear;
            _boxCollider.enabled = false;
            _isLit = false;
        }
      
        public void Collision(Collision2D collision)
        {
            if (collision.collider.CompareTag("TestBall"))
            {
                if (collision.rigidbody != null)
                {
                    Vector2 normal = Vector2.zero;
                    if (collision.contactCount > 0)
                    {
                        ContactPoint2D contact = collision.GetContact(0);
                        normal = contact.normal;

                    }
                    if (normal == Vector2.zero)
                    {
                        Vector2 direction = (collision.rigidbody.position - (Vector2)transform.position).normalized;
                        normal = direction;
                    }
                    normal *= -1;
                    Vector2 impulse = normal * _bumperForce;
                    collision.rigidbody.AddForce(impulse, ForceMode2D.Impulse);

                }

                if (!_isLit)
                {
                    StartCoroutine(LightUp());
                }

            }//End of If collision
        }
    }
}
