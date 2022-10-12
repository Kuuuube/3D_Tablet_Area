using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin;
using System;
using System.Numerics;

namespace Three_Dimensional_Tablet_Area
{
    [PluginName("3D Tablet Area Split Area")]
    public class Three_Dimensional_Tablet_Area_Split_Area : Three_Dimensional_Tablet_Area_Base
    {
        public static uint hover_store = 0;
        public static int flip_split_int;

        public Vector2 Three_Dimensional(Vector2 input)
        {
            if (Flip_Splitting)
            {
                flip_split_int = 1;
            }
            else
            {
                flip_split_int = 0;
            }

            if (hover_store >= Split_Hover_Value && Split_X)
            {
                input.X = (input.X + 1) / 2 - (1 * flip_split_int);
            }
            if (hover_store < Split_Hover_Value && Split_X)
            {
                input.X = (input.X - 1) / 2 + (1 * flip_split_int);
            }
            if (hover_store < Split_Hover_Value && Split_Y)
            {
                input.Y = (input.Y - 1) / 2 + (1 * flip_split_int);
            }
            if (hover_store >= Split_Hover_Value && Split_Y)
            {
                input.Y = (input.Y + 1) / 2 - (1 * flip_split_int);
            }

            return input;
        }

        public override event Action<IDeviceReport> Emit;

        public override void Consume(IDeviceReport value)
        {
            if (value is ITabletReport report)
            {
                report.Position = Filter(report.Position);
                value = report;
            }
            if (value is IProximityReport report2)
            {
                hover_store = report2.HoverDistance;
            }

            Emit?.Invoke(value);
        }

        public Vector2 Filter(Vector2 input) => FromUnit(Clamp(Three_Dimensional(ToUnit(input))));

        public override PipelinePosition Position => PipelinePosition.PostTransform;

        [Property("Split Hover Value"), DefaultPropertyValue(40f)]
        public float Split_Hover_Value { get; set; }

        [BooleanProperty("Split by X Axis", ""), DefaultPropertyValue(true)]
        public bool Split_X { get; set; }

        [BooleanProperty("Split by Y Axis", "")]
        public bool Split_Y { get; set; }

        [BooleanProperty("Flip Splitting", "")]
        public bool Flip_Splitting { get; set; }
    }
}