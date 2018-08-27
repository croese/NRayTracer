using NRayTracer.Core;
using System;

namespace NRayTracer.ProjectileDemo
{
    internal class Projectile
    {
        public Projectile(Vector3 startPoint, Vector3 initialVelocityVector)
        {
            Position = startPoint;
            Velocity = initialVelocityVector;
        }

        public Vector3 Position { get; }
        public Vector3 Velocity { get; }
    }

    internal class World
    {
        public World(Vector3 gravity, Vector3 wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public Vector3 Gravity { get; }
        public Vector3 Wind { get; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Projectile Demo");

            var p = new Projectile(new Vector3(0, 1, 0), new Vector3(1, 1, 0).Normalized);
            var w = new World(new Vector3(0, -0.1, 0), new Vector3(-0.01, 0, 0));
            var numTicks = 0;
            Console.WriteLine($"Y: {p.Position.Y}, Ticks: {numTicks}");
            while (p.Position.Y > 0)
            {
                p = Tick(w, p);
                numTicks++;
                Console.WriteLine($"Y: {p.Position.Y}, Ticks: {numTicks}");
            }

            Console.WriteLine($"It took {numTicks} ticks to hit the ground.");

            Console.Read();
        }

        private static Projectile Tick(World w, Projectile p)
        {
            var position = p.Position + p.Velocity;
            var velocity = p.Velocity + w.Gravity + w.Wind;
            return new Projectile(position, velocity);
        }
    }
}
