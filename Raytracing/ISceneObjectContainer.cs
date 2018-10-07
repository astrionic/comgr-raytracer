﻿using System.Collections.Generic;

namespace Raytracing {

    /// <summary>
    /// Represents a container for drawable scene objects.
    /// </summary>
    interface ISceneObjectContainer {

        /// <summary>
        /// Adds a scene object to the container.
        /// </summary>
        /// <param name="sceneObject">The scene object to add to the scene</param>
        void Add(ISceneObject sceneObject);

        /// <summary>
        /// Adds multiple scene objects to the container.
        /// </summary>
        /// <param name="sceneObjects">The scene objects to add to the container</param>
        void Add(IEnumerable<ISceneObject> sceneObjects);

        /// <summary>
        /// Finds the closest intersection of a given ray with a drawable object in the scene.
        /// </summary>
        /// <param name="ray">The ray, e.g. an eye ray</param>
        /// <returns>
        /// A <see cref="HitPoint"/> object containing information about the intersection, including the position in
        /// three-dimensional space and the surface normal.
        /// </returns>
        HitPoint FindClosestHitPoint(Ray ray);
    }
}
