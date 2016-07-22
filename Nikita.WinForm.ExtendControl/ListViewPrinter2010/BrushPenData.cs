using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Text;

namespace Nikita.WinForm.ExtendControl
{
    [Editor(typeof(BrushDataEditor), typeof(UITypeEditor)),
        TypeConverter(typeof(BrushDataConverter))]
    public interface IBrushData
    {
        Brush GetBrush();
    }

    public class HatchBrushData : IBrushData
    {
        private Color backgroundColor = Color.AliceBlue;

        private Color foregroundColor = Color.Aqua;

        private HatchStyle hatchStyle = HatchStyle.Cross;

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        public Color ForegroundColor
        {
            get { return foregroundColor; }
            set { foregroundColor = value; }
        }

        public HatchStyle HatchStyle
        {
            get { return hatchStyle; }
            set { hatchStyle = value; }
        }

        public Brush GetBrush()
        {
            return new HatchBrush(this.HatchStyle, this.ForegroundColor, this.BackgroundColor);
        }
    }

    public class LinearGradientBrushData : IBrushData
    {
        private Color fromColor = Color.Aqua;

        private LinearGradientMode gradientMode = LinearGradientMode.Horizontal;

        private Color toColor = Color.Pink;

        public Color FromColor
        {
            get { return fromColor; }
            set { fromColor = value; }
        }

        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set { gradientMode = value; }
        }

        public Color ToColor
        {
            get { return toColor; }
            set { toColor = value; }
        }

        public Brush GetBrush()
        {
            return new LinearGradientBrush(new Rectangle(0, 0, 100, 100), this.FromColor, this.ToColor, this.GradientMode);
        }
    }

    /// <summary>
    /// PenData represents the data required to create a pen.
    /// </summary>
    /// <remarks>Pens cannot be edited directly within the IDE (is this VCS EE only?)
    /// These objects allow pen characters to be edited within the IDE and then real
    /// Pen objects created.</remarks>
    [Editor(typeof(PenDataEditor), typeof(UITypeEditor)),
    TypeConverter(typeof(PenDataConverter))]
    public class PenData
    {
        private IBrushData brushData;

        private DashCap dashCap = DashCap.Round;

        private DashStyle dashStyle = DashStyle.Solid;

        private LineCap endCap = LineCap.NoAnchor;

        private LineJoin lineJoin = LineJoin.Round;

        private LineCap startCap = LineCap.NoAnchor;

        private float width = 1.0f;

        public PenData()
            : this(new SolidBrushData())
        {
        }

        public PenData(IBrushData brush)
        {
            this.Brush = brush;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IBrushData Brush
        {
            get { return brushData; }
            set { brushData = value; }
        }

        [DefaultValue(typeof(DashCap), "Round")]
        public DashCap DashCap
        {
            get { return dashCap; }
            set { dashCap = value; }
        }

        [DefaultValue(typeof(DashStyle), "Solid")]
        public DashStyle DashStyle
        {
            get { return dashStyle; }
            set { dashStyle = value; }
        }

        [DefaultValue(typeof(LineCap), "NoAnchor")]
        public LineCap EndCap
        {
            get { return endCap; }
            set { endCap = value; }
        }

        [DefaultValue(typeof(LineJoin), "Round")]
        public LineJoin LineJoin
        {
            get { return lineJoin; }
            set { lineJoin = value; }
        }

        [DefaultValue(typeof(LineCap), "NoAnchor")]
        public LineCap StartCap
        {
            get { return startCap; }
            set { startCap = value; }
        }

        [DefaultValue(1.0f)]
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public Pen GetPen()
        {
            Pen p = new Pen(this.Brush.GetBrush(), this.Width);
            p.SetLineCap(this.StartCap, this.EndCap, this.DashCap);
            p.DashStyle = this.DashStyle;
            p.LineJoin = this.LineJoin;
            return p;
        }
    }

    public class SolidBrushData : IBrushData
    {
        private int alpha = 255;

        private Color color = Color.Empty;

        [DefaultValue(255)]
        public int Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        [DefaultValue(typeof(Color), "")]
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Brush GetBrush()
        {
            if (this.Alpha < 255)
                return new SolidBrush(Color.FromArgb(this.Alpha, this.Color));
            else
                return new SolidBrush(this.Color);
        }
    }

    public class TextureBrushData : IBrushData
    {
        private Image image;

        private WrapMode wrapMode = WrapMode.Tile;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public WrapMode WrapMode
        {
            get { return wrapMode; }
            set { wrapMode = value; }
        }

        public Brush GetBrush()
        {
            if (this.Image == null)
                return null;
            else
                return new TextureBrush(this.Image, this.WrapMode);
        }
    }
}