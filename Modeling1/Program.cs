using Modeling1;


int from;
int to;
int precision;

Console.Write("Из каких? (1 - декартовы, 2 - цилиндрические, 3 - сферические): ");
from = Convert.ToInt32(Console.ReadLine());

Console.Write("В какие? (1 - декартовы, 2 - цилиндрические, 3 - сферические): ");
to = Convert.ToInt32(Console.ReadLine());

Console.Write("Точность?: ");
precision = Convert.ToInt32(Console.ReadLine());

ICoordinates coordinatesFrom;

if (from == 1)
{
    Console.WriteLine("Координаты декартовы через пробел: ");
    string[] input = Console.ReadLine().Split(' ');
    double first = Convert.ToDouble(input[0]);
    double second = Convert.ToDouble(input[1]);
    double third = Convert.ToDouble(input[2]);
    coordinatesFrom = new CartesianCoordinates(first, second, third);
}
else if (from == 2)
{
    Console.WriteLine("Координаты цилиндрические через пробел: ");
    string[] input = Console.ReadLine().Split(' ');
    double first = Convert.ToDouble(input[0]);
    double second = Convert.ToDouble(input[1]);
    double third = Convert.ToDouble(input[2]);
    coordinatesFrom = new CylCoordinates(first, second, third);
}
else if (from == 3)
{
    Console.WriteLine("Координаты сферические через пробел: ");
    string[] input = Console.ReadLine().Split(' ');
    double first = Convert.ToDouble(input[0]);
    double second = Convert.ToDouble(input[1]);
    double third = Convert.ToDouble(input[2]);
    coordinatesFrom = new SphCoordinates(first, second, third);
}
else
{
    return;
}


var coordinatesCartesian = coordinatesFrom.ToCartesian();

ICoordinates coordinatesTo;
switch (to)
{
    case 1:
        coordinatesTo = coordinatesFrom;
        break;
    case 2:
        coordinatesTo = ConvertCartesian.ToCylindric(coordinatesCartesian, precision);
        break;
    case 3:
        coordinatesTo = ConvertCartesian.ToSpherical(coordinatesCartesian, precision);
        break;
    default:
        return;
}

Console.WriteLine(coordinatesTo.ToString());

