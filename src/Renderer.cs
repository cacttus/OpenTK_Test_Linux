﻿using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using Vec2f = OpenTK.Vector2;
using Vec3f = OpenTK.Vector3;
using Vec4f = OpenTK.Vector4;

namespace PirateCraft
{
    /*
     *  Draw visible (culled) sets
     * */
    public class Renderer
    {
//        //private OpenTK.GLControl _objControl;
//        //..private BaseShader _objMainShader;
//        //private Scene _objNodeManager;
//        public bool ShowAxis { get; set; } = false;
//        //public BaseCamera _objCamera;
//        public bool ShowGrid { get; set; } = true;

//       //public BaseCamera GetCamera() { return _objCamera; }
//        // public GLControl GetControl() { return _objControl; }
//        public Int64 FrameStamp { get;  private set; }
//        public Viewport Viewport { get; private set; }
//        public void SetBackgroundColor(Vec4f color)
//        {
//            GL.ClearColor(color.X, color.Y, color.Z, color.W);
//        }
        public Renderer(Camera3D bc, VisibleSet vs)
        {
            //CreateViewport();

            //if (blnOrtho)
            //{
            //    _objCamera = new CameraOrtho2d(this, _objNodeManager);
            //    _objCamera.SetPos(new Vec3f(0.0f, 0.0f, -30));
            //    _objCamera.SetView(Vec3f.Normalize(new Vec3f(0, 0, -1)));
            //}
            //else
            //{
            //    _objCamera = new Camera3d(this, _objNodeManager);
            //    _objCamera.SetPos(new Vec3f(20.0f, 20.0f, -20));
            //    _objCamera.SetView(Vec3f.Normalize(new Vec3f(-1, -1, 1)));
            //}
            //GL.CullFace(CullFaceMode.Back);
            //GL.FrontFace(FrontFaceDirection.Ccw);
            //GL.ActiveTexture(TextureUnit.Texture0);
            //GL.Enable(EnableCap.Texture2D);
            //GL.Enable(EnableCap.DepthTest);
            //GL.Enable(EnableCap.ScissorTest);
            ////GL.Disable(EnableCap.CullFace);
            //SetBackgroundColor(new Vec4f(0, 0, 0, 0));

            //_objMainShader = new BaseShader();
            //_objMainShader.Load();
        }
//        //private void _objOpenGl_Resize(object sender, EventArgs e)
//        //{
//        //    Resize();
//        //}

//        public void Resize()
//        {
//            //_objNodeManager.Resize(Viewport);
//        }
//        //private void CreateViewport()
//        //{
//        //    //Don't allow 0 width/height
//        //    // Use 2 because of integer divison
//        //    //int mw = _objControl.Width < 2 ? 2 : _objControl.Width;
//        //    //int mh = _objControl.Height < 2 ? 2 : _objControl.Height;
//        //    //Viewport = new Viewport(mw, mh);
//        //}
//        public void Redraw()
//        {
//            Gu.CheckGpuErrorsDbg();
//            Begin();

//            foreach (BaseNode node in _objNodeManager.GetNodes())
//            {
//                if (node == null)
//                {
//                    return;
//                }
//                Gu.CheckGpuErrorsDbg();
//                GL.PushMatrix();
//                {
//                    Gu.CheckGpuErrorsDbg();
//                    GL.Translate(node.GetPos());
//                    Gu.CheckGpuErrorsDbg();
//                    GL.Rotate(node.GetRotation(), node.GetRotationVector());
//                    Gu.CheckGpuErrorsDbg();
//                    GL.Scale(node.GetScale());
//                    Gu.CheckGpuErrorsDbg();
//                    node.UpdateBoundBox();
//                    DrawNode(node);
//                }
//                GL.PopMatrix();
//            }

//            End();
//            Gu.CheckGpuErrorsDbg();

//            //_objControl.Invalidate();
//        }
//        private Color4 _lastClearColor = Color4(1,1,1,1);
//        public void Begin(Color4? c = null)
//        {
//            if (c!=null && c!=_lastClearColor) 
//            {
//                GL.ClearColor(c);
//            }

//            //Clear, set matrix
//            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
//            Gu.CheckGpuErrorsDbg();

//            // Camera setup
//            _objCamera.Setup();
//            Gu.CheckGpuErrorsDbg();
//        }
//        public void DrawNode(BaseNode node)
//        {
//            //Call bind  here in order to send the correct matrix.
//            if (_objMainShader.IsLoaded())
//            {
//                _objMainShader.UpdateAndBind();
//            }
//            node.Render(this);
//        }
//        float angle = 0;
//        public void End()
//        {
//            if (_objMainShader.IsLoaded())
//            {
//                _objMainShader.Unbind();
//            }

//            Gu.CheckGpuErrorsDbg();
//            {
//                GL.PushMatrix();
//                angle += 10.0f;
//                //  GL.Rotate(angle, 0, 1, 0);

//                // - Fixed function code goes here.
//                GL.Disable(EnableCap.Texture2D);
//                GL.UseProgram(0);
//                if (ShowAxis)
//                {
//                    GL.LineWidth(3.0f);
//                    float al = 20.0f;    // Make this smaller for non-ortho mode.
//                    GL.Begin(PrimitiveType.Lines);
//                    GL.Color4(1.0f, 0.0f, 0.0f, 1.0f);
//                    GL.Vertex3(0, 0.0f, 0.0f);
//                    GL.Vertex3(al, 0.0f, 0.0f);
//                    GL.Color4(0.0f, 1.0f, 0.0f, 1.0f);
//                    GL.Vertex3(0.0f, 0, 0.0f);
//                    GL.Vertex3(0.0f, al, 0.0f);
//                    GL.Color4(0.0f, 0.0f, 1.0f, 1.0f);
//                    GL.Vertex3(0.0f, 0.0f, 0);
//                    GL.Vertex3(0.0f, 0.0f, al);
//                    GL.End();
//                }

//                if (ShowGrid)
//                {
//                    renderGrid(1, 1, 1, 10, 10, new Vec3f(0, 0, 0));
//                }
//                GL.PopMatrix();
//            }
//            Gu.CheckGpuErrorsDbg();

//            FrameStamp++;

//            //Single RT error checking at the end of the loop
//            Gu.CheckGpuErrorsRt();
//        }

//        void renderGrid(float r, float g, float b, int nSlices, float fSliceWidth, Vec3f center)
//        {
//            GL.PushAttrib(AttribMask.AllAttribBits);

//            GL.Disable(EnableCap.CullFace);

//            float gridWidth_2 = nSlices * fSliceWidth / 2.0f;

//            GL.LineWidth(1.0f);
//            GL.Begin(PrimitiveType.Lines);
//            GL.Color3(r, g, b);
//            //Horiz lines
//            for (int i = 0; i < nSlices + 1; ++i)
//            {
//                GL.Vertex3(center.X - (gridWidth_2),
//                    center.Y - 0,
//                    center.Z - (gridWidth_2) + (fSliceWidth * (float)i)
//                    );
//                GL.Vertex3(center.X + (gridWidth_2),
//                    center.Y - 0,
//                    center.Z - (gridWidth_2) + (fSliceWidth * (float)i)
//                    );
//            }
//            for (int i = 0; i < nSlices + 1; ++i)
//            {
//                GL.Vertex3(center.X - (gridWidth_2) + (fSliceWidth * (float)i),
//                    center.Y - 0,
//                    center.Z - (gridWidth_2)
//                    );
//                GL.Vertex3(center.X - (gridWidth_2) + (fSliceWidth * (float)i),
//                    center.Y - 0,
//                    center.Z + (gridWidth_2)
//                    );
//            }
//            GL.End();

//            GL.PopAttrib();

    //   }

















    }
}
