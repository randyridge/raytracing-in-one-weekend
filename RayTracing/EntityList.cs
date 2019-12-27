using System.Collections.Generic;
using RandyRidge.Common;

namespace RayTracing {
    public sealed class EntityList : IEntity {
        private readonly List<IEntity> entities;

        public EntityList(List<IEntity> entities) {
            this.entities = Guard.NotNull(entities, nameof(entities));

        }
        public Hit? Hit(in Ray ray, float minimum, float maximum) {
            float closest = maximum;
            Hit? hit = null;
            for(var i = 0; i < entities.Count; i++) {
                var testHit = entities[i].Hit(ray, minimum, closest);
                if(!testHit.HasValue) {
                    continue;
                }

                closest = testHit.Value.Time;
                hit = testHit;
            }
            return hit;
        }
    }
}
