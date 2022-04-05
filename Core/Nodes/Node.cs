using System.Collections.Generic; // List<>
using System.Numerics; // Vector2

namespace Movement
{
	abstract class Node
	{
		// Transform: public fields!!!
		public Vector2 Position;
		public double Rotation;
		public Vector2 Scale;

		// Data structure
		private List<Node> children;
		public List<Node> Children {
			get { return children; }
		}
		private Node parent;

		// Node.TransformNode sets these values after transform.
		private Vector2 worldPosition;
		private float worldRotation;
		private Vector2 worldScale;

		public Vector2 WorldPosition {
			get { return worldPosition; }
		}
		public float WorldRotation {
			get { return worldRotation; }
		}
		public Vector2 WorldScale {
			get { return worldScale; }
		}

		// Constructor
		protected Node()
		{
			// setup data structure
			children = new List<Node>();
			parent = null;

			// default transform
			Position = new Vector2(0.0f, 0.0f);
			Rotation = 0.0f;
			Scale = new Vector2(1.0f, 1.0f);
		}

		public virtual void Update(float deltaTime)
		{
			// virtual (override in subclass)
			// or don't, then this will be called
		}

		public bool AddChild(Node child)
		{
			if (children.Contains(child))
			{
				// this is already our child
				return false;
			}
			if (child == this)
			{
				// this is us! we can't be our own child.
				return false;
			}
			if (child.parent != null) // handle previous owner
			{
				// "kidnap" the child from previous parent
				child.parent.RemoveChild(child, false);
			}
			child.parent = this;
			children.Add(child);
			return true;
		}

		public bool RemoveChild(Node child, bool keepAlive = false)
		{
			// we don't know this child
			if (!children.Contains(child))
			{
				return false;
			}

			// do we need to keep this child alive?
			if (keepAlive)
			{
				// pass back up to our parent
				if (this.parent == null)
				{
					// we're the scene, we have no parents
					return false;
				}
				child.parent = this.parent;
				child.parent.AddChild(child);
			}

			// remove from our children
			children.Remove(child);
			return true;
		}

		public void TransformNode(Matrix4x4 parentMatrix)
		{
			// ========== Transform all nodes ==========
			// locals (we need Vec3 to use with Mat4 in System.Numerics)
			Vector3 position = new Vector3(Position, 0.0f);
			Vector3 rotation = new Vector3(0.0f, 0.0f, (float)Rotation);
			Vector3 scale = new Vector3(Scale, 0.0f);

			// build individual translation, rotation and scale Matrices
			Matrix4x4 translationMatrix = Matrix4x4.CreateTranslation(position);
			Matrix4x4 rotMatZ = Matrix4x4.CreateRotationZ(rotation.Z);
			// Matrix4x4 rotMatX = Matrix4x4.CreateRotationX(rotation.X);
			// Matrix4x4 rotMatY = Matrix4x4.CreateRotationX(rotation.Y);
			// Matrix4x4 rotationMatrix = rotMatX * rotMatY * rotMatZ;
			Matrix4x4 scaleMatrix = Matrix4x4.CreateScale(scale);

			// build modelMatrix for this Entity
			// Matrix4x4 modelMatrix = scaleMatrix * rotationMatrix * translationMatrix;
			Matrix4x4 modelMatrix = scaleMatrix * rotMatZ * translationMatrix;

			// multiply with parent
			modelMatrix *= parentMatrix;

			// extract world coords
			Vector3 worldpos;
			Quaternion worldrotQ;
			Vector3 worldscl;
			Matrix4x4.Decompose(modelMatrix, out worldscl, out worldrotQ, out worldpos);

			// set World coords
			worldPosition = new Vector2(worldpos.X, worldpos.Y);
			worldRotation = Vector3.Transform(rotation, worldrotQ).Z; // TODO check
			// Rotation is not inherited from parent. For now, we hack it in.
			if (parent != null) {
				worldRotation = parent.WorldRotation + (float)Rotation;
			}
			worldScale = new Vector2(worldscl.X, worldscl.Y);

			// transform all children
			for (int i=0; i<children.Count; i++)
			{
				children[i].TransformNode(modelMatrix);
			}
		}

	}
}
