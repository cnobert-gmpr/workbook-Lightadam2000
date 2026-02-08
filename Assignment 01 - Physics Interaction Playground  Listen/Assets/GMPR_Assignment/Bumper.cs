namespace GMPR_Assignment.assignment1
{
    using System.Collections;
    using UnityEngine;

    public class Bumper : MonoBehaviour
    {
        [SerializeField] private float _bumperForce = 150, _litDuration = 0.2f;
        [SerializeField] private Color _litColour = Color.yellow;

        private bool _isLit = false;
        private SpriteRenderer _spriteRenderer;
        private Color _originalColour;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColour = _spriteRenderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                if (collision.rigidbody != null)
                {
                    Vector2 normal = Vector2.zero;
                    if (collision.contactCount > 0) 
                    {
                        ContactPoint2D contact = collision.GetContact(0);
                        normal = contact.normal;
                    
                    }
                    if(normal == Vector2.zero)
                    {
                        Vector2 direction = (collision.rigidbody.position - (Vector2)transform.position).normalized;
                        normal = direction;
                    }
                    normal *= -1;
                    Vector2 impulse = normal * _bumperForce;
                    collision.rigidbody.AddForce(impulse,ForceMode2D.Impulse);

                }

                if (!_isLit)
                {
                    StartCoroutine(LightUp());
                }

            }
        }//End of OnCollision
        private IEnumerator LightUp()
        {
            _isLit = true;
            _spriteRenderer.color = _litColour;
            yield return new WaitForSeconds(_litDuration);
            _spriteRenderer.color = _originalColour;
            _isLit = false;
        }
    }
}