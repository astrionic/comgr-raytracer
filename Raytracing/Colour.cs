﻿using System;
using System.Numerics;

// TODO this whole thing is probably unnecessary, should be converted into extension methods for Vector3?
namespace Raytracing {
    public class Colour {
        public static readonly Vector3 Black = new Vector3(0, 0, 0);
        public static readonly Vector3 Red = new Vector3(1, 0, 0);
        public static readonly Vector3 Green = new Vector3(0, 1, 0);
        public static readonly Vector3 Blue = new Vector3(0, 0, 1);
        public static readonly Vector3 Yellow = new Vector3(1, 1, 0);
        public static readonly Vector3 Magenta = new Vector3(1, 0, 1);
        public static readonly Vector3 Cyan = new Vector3(0, 1, 1);
        public static readonly Vector3 White = new Vector3(1, 1, 1);
        public static readonly Vector3 LightCyan = new Vector3(0.8f, 1, 1);
    }
}
