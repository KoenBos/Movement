using System;
using Raylib_cs;

namespace Movement
{
	class Example110 : SceneNode
	{
		// private fields
		private Follower follower;

		// constructor + call base constructor
		public Example110(String t) : base(t)
		{
			follower = new Follower();
			AddChild(follower);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

	} // class

} // namespace
