using NRayTracer.Core;
using System;
using Tuple = NRayTracer.Core.Tuple;

namespace NRayTracer.ProjectileDemo
{
    internal class Projectile
    {
        public Projectile(Tuple4 startPoint, Tuple4 initialVelocityVector)
        {
            Position = startPoint;
            Velocity = initialVelocityVector;
        }

        public Tuple4 Position { get; }
        public Tuple4 Velocity { get; }
    }

    internal class World
    {
        public World(Tuple4 gravity, Tuple4 wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public Tuple4 Gravity { get; }
        public Tuple4 Wind { get; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Projectile Demo");

            var p = new Projectile(Tuple.NewPoint(0, 1, 0), Tuple.NewVector(1, 1, 0).Normalized);
            var w = new World(Tuple.NewVector(0, -0.1, 0), Tuple.NewVector(-0.01, 0, 0));
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
