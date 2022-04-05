using System;
using Raylib_cs;

namespace Movement
{
	class Example303 : SceneNode
	{
		// private fields
		private Pointer pointer;

		// constructor + call base constructor
		public Example303(String t) : base(t)
		{
			pointer = new Pointer();
			AddChild(pointer);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			// Or just implement it in Example 110 Follower
			base.Update(deltaTime);
		}

	} // class

} // namespace
