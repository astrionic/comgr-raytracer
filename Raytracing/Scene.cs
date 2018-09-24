﻿using System.Collections.Generic;

namespace Raytracing {
    public class Scene {
        private List<ISceneObject> SceneObjects;

        public void AddObject(ISceneObject sceneObject) {
            SceneObjects.Add(sceneObject);
        }

        public void AddObjects(IEnumerable<ISceneObject> sceneObjects) {
            SceneObjects.AddRange(sceneObjects);
        }
    }
}