﻿// A FIGlet generation library - MIT license
// https://github.com/picrap/FIGlet

namespace FIGlet.Blend
{
    using System.Linq;
    using Drawing;

    /// <summary>
    ///     Tries several blending
    /// </summary>
    /// <seealso cref="FIGlet.Blend.IDrawingElementBlender" />
    public class MultiDrawingElementBlender : IDrawingElementBlender
    {
        private readonly IDrawingElementBlender[] _blenders;

        public MultiDrawingElementBlender(params IDrawingElementBlender[] blenders)
        {
            _blenders = blenders;
        }

        public DrawingElement TryBlend(DrawingElement under, DrawingElement over)
        {
            return _blenders.Select(b => b.TryBlend(under, over)).FirstOrDefault(e => !(e is null));
        }
    }
}