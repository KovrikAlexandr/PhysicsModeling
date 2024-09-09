namespace Modeling1;

interface ICoordinates
{
    public string ToString();

    public CartesianCoordinates ToCartesian();
}

public class CartesianCoordinates : ICoordinates
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public CartesianCoordinates(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public string ToString()
    {
        return new($"(x = {X}, y = {Y}, z = {Z})");
    }

    public CartesianCoordinates ToCartesian()
    {
        return this;
    }
}

public class CylCoordinates : ICoordinates
{
    public double R { get; }
    
    public double Theta { get; }
    
    public double Z { get; }

    public CylCoordinates(double r, double theta, double z)
    {   
        R = r;
        Theta = theta;
        Z = z;
    }
    
    public string ToString()
    {
        return new($"(r = {R}, theta = {Theta}, z = {Z})");
    }

    public CartesianCoordinates ToCartesian()
    {   
        // // double x = 
        // // double y = 
        // // double z = 
        // return new CartesianCoordinates();
        double x = R * Math.Cos(Theta);  // Расчет координаты X
        double y = R * Math.Sin(Theta);  // Расчет координаты Y
        double z = Z;
        
        return new CartesianCoordinates(x, y, z);
    }
}

public class SphCoordinates : ICoordinates
{
    public SphCoordinates(double r, double theta, double phi)
    {
        R = r;
        Theta = theta;
        Phi = phi;
    }
    
    public double R { get; }
    
    public double Theta { get; }
    
    public double Phi { get; }
    
    public string ToString()
    {
        return new($"r = {R}, theta = {Theta}, phi = {Phi}");
    }

    public CartesianCoordinates ToCartesian()
    {
        double x = R * Math.Sin(Phi) * Math.Cos(Theta);  // Расчет координаты X
        double y = R * Math.Sin(Phi) * Math.Sin(Theta);  // Расчет координаты Y
        double z = R * Math.Cos(Phi);
        
        return new CartesianCoordinates(x, y, z);
    }
}

class ConvertCartesian
{
    public static CylCoordinates ToCylindric(CartesianCoordinates dc, int precision)
    {
        double x = dc.X;
        double y = dc.Y;
        double z = dc.Z;

        double r = Math.Round(Math.Sqrt(x * x + y * y), precision);
        double theta = Math.Round(Math.Atan2(y, x), precision);
        z = Math.Round(z, precision);
        
        return new CylCoordinates(r, theta, z);
    }

    public static SphCoordinates ToSpherical(CartesianCoordinates dc, int precision)
    {
        double x = dc.X;
        double y = dc.Y;
        double z = dc.Z;

        double r = Math.Round(Math.Sqrt(x * x + y * y + z * z), precision);
        double theta = Math.Round(Math.Atan2(y, x), precision);
        double phi = Math.Round(Math.Acos(z / r), precision);
        
        return new SphCoordinates(r, theta, phi);
    }
}




