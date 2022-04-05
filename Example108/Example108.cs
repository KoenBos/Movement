using System;
using Raylib_cs;

namespace Movement
{
	class Example108 : SceneNode
	{
		// private fields
		private AcceleratingBall ball;

		// constructor + call base constructor
		public Example108(String t) : base(t)
		{
			ball = new AcceleratingBall();
			AddChild(ball);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

	} // class

} // namespace
