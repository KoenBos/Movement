using System.Numerics;

namespace Movement
{
	abstract class MoverNode : SpriteNode
	{
		private Vector2 velocity;
		private Vector2 acceleration;
		private float mass;

		public Vector2 Velocity { 
			get { return velocity; }
			set { velocity = value; }
		}
		public Vector2 Acceleration { 
			get { return acceleration; }
			set { acceleration = value; }
		}
		public float Mass { 
			get { return mass; }
			private set { mass = value; }
		}

		// constructor
		protected MoverNode(string title) : base(title)
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
		protected void Move(float deltaTime)
		{
			// Motion 101. Apply the rules.
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
			// Reset acceleration
			Acceleration *= 0.0f;
		}

		protected void AddForce(Vector2 force)
		{
			Acceleration += force / Mass;
		}

	}
}
