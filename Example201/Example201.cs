using System;
using Raylib_cs;

namespace Movement
{
	class Example201 : SceneNode
	{
		// private fields
		private BouncingBall ball;

		// constructor + call base constructor
		public Example201(String t) : base(t)
		{
			ball = new BouncingBall();
			AddChild(ball);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

	} // class

} // namespace
