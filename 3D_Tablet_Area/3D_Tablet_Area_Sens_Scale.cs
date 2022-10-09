using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin;
using System;
using System.Numerics;

namespace Three_Dimensional_Tablet_Area
{
    [PluginName("3D Tablet Area Sens Scale")]
    public class Three_Dimensional_Tablet_Area_Sens_Scale : Three_Dimensional_Tablet_Area_Base
    {
        public static uint hover_store = 0;

        public Vector2 Three_Dimensional(Vector2 input)
        {
            var weighted_hover = (hover_store - Min_Hover_Value) / (Max_Hover_Value - Min_Hover_Value) * (Max_Multiplier - Min_Multiplier) + Min_Multiplier;
            return input * weighted_hover;
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

        [Property("Min Multiplier"), DefaultPropertyValue(1f)]
        public float Min_Multiplier { get; set; }

        [Property("Max Multiplier"), DefaultPropertyValue(5f)]
        public float Max_Multiplier { get; set; }

        [Property("Min Hover Value"), DefaultPropertyValue(1f)]
        public float Min_Hover_Value { get; set; }

        [Property("Max Hover Value"), DefaultPropertyValue(255f)]
        public float Max_Hover_Value { get; set; }
    }
}