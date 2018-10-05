﻿using System;
using System.Numerics;

namespace Raytracing {
    public class HitPoint {
        public float Lambda { get; }
        public Vector3 Position { get; }
        public Vector3 Normal { get; }
        public ISceneObject HitObject { get; }

        public HitPoint(float lambda, Vector3 position, Vector3 normal, ISceneObject hitObject) {
            this.Lambda = lambda;
            this.Position = position;
            this.Normal = normal;
            this.HitObject = hitObject;
        }

        internal Vector3 Diffuse(LightSource lightSource) {
            Vector3 L = Vector3.Normalize(lightSource.Position - this.Position);
            float nL = Vector3.Dot(this.Normal, L);
            Vector3 diffuse = this.HitObject.Texture != null ? this.GetTextureColour() : this.HitObject.Material.Diffuse;
            return nL >= 0 ? (Vector3.Multiply(lightSource.Colour, diffuse) * nL) : Colour.Black;
        }

        internal Vector3 Phong(LightSource lightSource, Vector3 cameraPosition, int k = 40) {
            Vector3 L = Vector3.Normalize(lightSource.Position - this.Position); // TODO maybe move this calculation out of the method because it's repeated in other methods
            float nL = Vector3.Dot(this.Normal, L);
            Vector3 eh = Vector3.Normalize(this.Position - cameraPosition);
            Vector3 r = Vector3.Normalize(2 * nL * this.Normal - L);
            return nL >= 0 ? lightSource.Colour * (float)Math.Pow(Vector3.Dot(r, eh), k) : Colour.Black;
        }

        internal Vector3 Fresnel(Ray ray) {
            return (Vector3)this.HitObject.Material.Reflective + (Vector3.One - (Vector3)this.HitObject.Material.Reflective)
                * (float)Math.Pow(1 - Vector3.Dot(this.Normal, Vector3.Reflect(ray.Direction, this.Normal)), 5);
        }

        private Vector3 GetTextureColour() {
            float s = (float)Math.Atan2(this.Normal.X, this.Normal.Z) / (2 * (float)Math.PI) + 0.5f;
            float t = ((float)Math.Acos(this.Normal.Y)) / (float)Math.PI;
            return this.HitObject.Texture.GetPixel(s, t);
        }
    }
}
