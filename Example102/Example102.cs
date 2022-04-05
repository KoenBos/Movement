using System;
using Raylib_cs;

namespace Movement
{
	class Example102 : SceneNode
	{
		// private fields
		private MovingBall ball;

		// constructor + call base constructor
		public Example102(String t) : base(t)
		{
			ball = new MovingBall();
			AddChild(ball);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

	} // class

} // namespace
