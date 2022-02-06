using UnityEngine;

namespace Birds
{
    public sealed class InteractiveObjectsDriver
    {
        private HitObjectProperties _properties;

        public void DriveHitObject(HitObject hitObject)
        {
            hitObject.gameObject.SetActive(true);

            _properties = hitObject.Properties;
            var maxSpeed = _properties.MaxSpeed;
            var minSpeed = _properties.MinSpeed;
            var speed = Random.Range(minSpeed, maxSpeed);

            Vector2 force;
            bool isTurnedLeft = hitObject.gameObject.GetComponent<SpriteRenderer>().flipX;

            if (isTurnedLeft)
            {
                speed *= -1;
                force = new Vector2(hitObject.transform.position.x * speed, 0);
            }
            else
            {
                var direction = -(hitObject.transform.position.x);
                force = new Vector2(direction * speed, 0);
            }
            var rb = hitObject.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(force);
        }

        public void StopHitObject(HitObject hitObject)
        {
            hitObject.gameObject.SetActive(false);
            hitObject.transform.position = Vector2.zero;
            hitObject.transform.localScale = Vector3.one;
            hitObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        public void DriveBonus(GameObject bonus)
        {
            bonus.SetActive(true);
            bonus.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        public void StopBonus(GameObject bonus)
        {
            bonus.SetActive(false);
            bonus.transform.localScale = Vector3.one;
            var rb = bonus.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
}
