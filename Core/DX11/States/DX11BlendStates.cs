﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimDX.Direct3D11;

namespace FeralTic.DX11
{
    public class DX11BlendStates : DX11RenderStates<BlendStateDescription>
    {
        private static DX11BlendStates instance;

        public static DX11BlendStates Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DX11BlendStates();
                    instance.Initialize();
                }
                return instance;
            }
        }


        public override string EnumName
        {
            get
            {
                return "DX11.BlendPresets";
            }
        }

        protected override void Initialize()
        {
            this.CreateNoBlend();
            this.CreateAddivite();
            this.CreateBlend();
            this.CreateMultiply();
            this.CreateAlphaAdd();
            this.CreateTextDefault();
            this.CreateKeep();
        }

        private void CreateNoBlend()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = false,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.InverseSourceAlpha,
                    DestinationBlendAlpha = BlendOption.One,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.SourceAlpha,
                    SourceBlendAlpha = BlendOption.One
                };
            }

            this.AddState("Disabled", bs);
        }

        private void CreateAddivite()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                //bs.IndependentBlendEnable 

                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = true,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.One,
                    DestinationBlendAlpha = BlendOption.One,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.One,
                    SourceBlendAlpha = BlendOption.One
                };
            }

            this.AddState("Add", bs);
        }

        private void CreateBlend()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = true,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.InverseSourceAlpha,
                    DestinationBlendAlpha = BlendOption.One,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.SourceAlpha,
                    SourceBlendAlpha = BlendOption.One
                };
            }

            this.AddState("Blend", bs);
        }

        private void CreateMultiply()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = true,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.Zero,
                    DestinationBlendAlpha = BlendOption.Zero,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.DestinationColor,
                    SourceBlendAlpha = BlendOption.DestinationAlpha
                };
            }

            this.AddState("Multiply", bs);
        }

        private void CreateAlphaAdd()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = true,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.One,
                    DestinationBlendAlpha = BlendOption.Zero,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.SourceAlpha,
                    SourceBlendAlpha = BlendOption.Zero
                };
            }

            this.AddState("AlphaAdd", bs);
        }

        private void CreateTextDefault()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = true,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.InverseSourceAlpha,
                    DestinationBlendAlpha = BlendOption.Zero,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.One,
                    SourceBlendAlpha = BlendOption.One
                };
            }

            this.AddState("TextDefault", bs);
        }

        private void CreateKeep()
        {
            BlendStateDescription bs = new BlendStateDescription()
            {
                AlphaToCoverageEnable = false,
                IndependentBlendEnable = false,
            };
            for (int i = 0; i < 8; i++)
            {
                //bs.IndependentBlendEnable 

                bs.RenderTargets[i] = new RenderTargetBlendDescription()
                {
                    BlendEnable = true,
                    BlendOperation = SlimDX.Direct3D11.BlendOperation.Add,
                    BlendOperationAlpha = SlimDX.Direct3D11.BlendOperation.Add,
                    DestinationBlend = BlendOption.One,
                    DestinationBlendAlpha = BlendOption.One,
                    RenderTargetWriteMask = ColorWriteMaskFlags.All,
                    SourceBlend = BlendOption.Zero,
                    SourceBlendAlpha = BlendOption.Zero
                };
            }

            this.AddState("Keep", bs);
        }
    }
}
