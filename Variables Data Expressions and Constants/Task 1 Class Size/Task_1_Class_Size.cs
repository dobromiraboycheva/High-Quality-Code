using System;

public class Size
{
    private double width, height;

    public Size(double currentWidth, double currentHeight)
    {
        this.width = currentWidth;
        this.height = currentHeight;
    }

    public static Size GetRotatedSize(Size geometricSize, double angleOfRotation)
    {
        var cosOfRotation = Math.Cos(angleOfRotation);
        var sinOfRotation = Math.Sin(angleOfRotation);

        var width = Math.Abs(cosOfRotation) * geometricSize.width + Math.Abs(sinOfRotation) * geometricSize.height;
        var height = Math.Abs(sinOfRotation) * geometricSize.width + Math.Abs(cosOfRotation) * geometricSize.height;

        Size rotatedSize = new Size(width, height);

        return rotatedSize;
    }
}