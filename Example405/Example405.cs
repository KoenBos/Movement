using System;
using Raylib_cs;

namespace Movement
{
	class Example405 : SceneNode
	{
		// private fields
		private ParticleSystem particlesystem01;
		private ParticleSystem particlesystem02;

		// constructor + call base constructor
		public Example405(String t) : base(t)
		{
			particlesystem01 = new ParticleSystem(320, 360);
			AddChild(particlesystem01);

			particlesystem02 = new ParticleSystem(960, 360);
			AddChild(particlesystem02);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

	} // class

} // namespace
