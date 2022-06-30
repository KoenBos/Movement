using System.Numerics;

namespace Movement
{
    abstract class MoverNode : SpriteNode
    {
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public float Mass;

        // constructor
        public MoverNode(string title) : base(title)
        {
            Velocity = new Vector2(0, 0);
            Acceleration = new Vector2(0, 0);
            Mass = 1.0f;
        }

        public override void Update(float deltaTime)
        {
            // override in your subclass
        }

        // Protected methods to be called from subclass
        public void Move(float deltaTime)
        {
            // Motion 101. Apply the rules.
            Velocity += Acceleration * deltaTime;
            Position += Velocity * deltaTime;
            // Reset acceleration
            Acceleration *= 0.0f;
        }

        public void AddForce(Vector2 force)
        {
            Acceleration += force / Mass;
        }

    }
}