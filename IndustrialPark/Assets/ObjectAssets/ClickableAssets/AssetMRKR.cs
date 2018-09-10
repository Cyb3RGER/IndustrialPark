﻿using HipHopFile;
using IndustrialPark.Models;
using SharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IndustrialPark
{
    public class AssetMRKR : Asset, IRenderableAsset, IClickableAsset
    {
        private Matrix world;
        private BoundingBox boundingBox;

        public static bool dontRender = false;

        public AssetMRKR(Section_AHDR AHDR) : base(AHDR)
        {
        }

        public void Setup(SharpRenderer renderer)
        {
            _position = new Vector3(ReadFloat(0x0), ReadFloat(0x4), ReadFloat(0x8));

            CreateTransformMatrix();

            if (!ArchiveEditorFunctions.renderableAssetSet.Contains(this))
                ArchiveEditorFunctions.renderableAssetSet.Add(this);
        }

        public void CreateTransformMatrix()
        {
            world = Matrix.RotationX(MathUtil.Pi) * Matrix.Translation(_position);

            CreateBoundingBox();
        }

        protected void CreateBoundingBox()
        {
            boundingBox =  BoundingBox.FromPoints(SharpRenderer.pyramidVertices.ToArray());
            boundingBox.Maximum = (Vector3)Vector3.Transform(boundingBox.Maximum, world);
            boundingBox.Minimum = (Vector3)Vector3.Transform(boundingBox.Minimum, world);
        }
        
        public float? IntersectsWith(Ray ray)
        {
            if (ray.Intersects(ref boundingBox, out float distance))
                return TriangleIntersection(ray, distance, SharpRenderer.pyramidTriangles, SharpRenderer.pyramidVertices);
            return null;
        }
        
        private float? TriangleIntersection(Ray r, float initialDistance, List<Triangle> triangles, List<Vector3> vertices)
        {
            bool hasIntersected = false;
            float smallestDistance = 1000f;

            foreach (Triangle t in triangles)
            {
                Vector3 v1 = (Vector3)Vector3.Transform(vertices[t.vertex1], world);
                Vector3 v2 = (Vector3)Vector3.Transform(vertices[t.vertex2], world);
                Vector3 v3 = (Vector3)Vector3.Transform(vertices[t.vertex3], world);

                if (r.Intersects(ref v1, ref v2, ref v3, out float distance))
                {
                    hasIntersected = true;

                    if (distance < smallestDistance)
                        smallestDistance = distance;
                }
            }

            if (hasIntersected)
                return smallestDistance;
            else return null;
        }

        public void Draw(SharpRenderer renderer)
        {
            if (dontRender) return;

            renderer.DrawCube(world, isSelected);
        }
        
        public virtual Vector3 GetGizmoCenter()
        {
            return boundingBox.Center;
        }

        public virtual float GetGizmoRadius()
        {
            return Math.Max(Math.Max(boundingBox.Size.X, boundingBox.Size.Y), boundingBox.Size.Z) * 0.9f;
        }

        public BoundingBox GetBoundingBox()
        {
            return boundingBox;
        }

        private Vector3 _position;
        public float PositionX
        {
            get { return _position.X; }
            set
            {
                _position.X = value;
                Write(0x0, _position.X);
                CreateTransformMatrix();
            }
        }

        public float PositionY
        {
            get { return _position.Y; }
            set
            {
                _position.Y = value;
                Write(0x4, _position.Y);
                CreateTransformMatrix();
            }
        }

        public float PositionZ
        {
            get { return _position.Z; }
            set
            {
                _position.Z = value;
                Write(0x8, _position.Z);
                CreateTransformMatrix();
            }
        }
    }
}