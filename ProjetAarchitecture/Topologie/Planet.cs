﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAarchitecture.Topologie
{
    public class Planet
    {
        public int Width { get; }
        public int Height { get; }
        private readonly List<Obstacle> _obstacles;

        public Planet(int width, int height, IEnumerable<Obstacle> obstacles = null)
        {
            Width = width;
            Height = height;
            _obstacles = obstacles?.ToList() ?? new List<Obstacle>();
        }
        public Position AdjustPosition(Position position)
        {
            int adjustedX = (position.X + Width) % Width;
            int adjustedY = (position.Y + Height) % Height;
            return new Position(adjustedX, adjustedY);
        }
    }
}
