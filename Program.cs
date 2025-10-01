using System;

using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Bienvenido(a) Te ayudare a calcular y guardar informacion salarial, empecemos ");

int operarios = 0, tecnicos = 0, profesionales = 0;

double netoOperarios = 0, netoTecnicos = 0, netoProfesionales = 0;

string seguir = "s";

while (seguir == "s")

{

    Console.Write("Ingresa la Cédula: ");

    string cedula = Console.ReadLine();

    Console.Write("Ingresa el Nombre: ");

    string nombre = Console.ReadLine();

    Console.Write("Escoge el tipo de empleado (1-Operario, 2-Tecnico, 3-Profesional): ");

    int tipo = int.Parse(Console.ReadLine());

    Console.Write("Ingresa las horas trabajadas: ");

    double horas = double.Parse(Console.ReadLine());

    Console.Write("Ingresa el precio por hora: ");

    double precio = double.Parse(Console.ReadLine());

    //double salario = horas * precio;

    //Llamado a la funcion fsalario

    double salario = fnsalario(horas, precio);

    double aumento = 0;


    if (tipo == 1)

    {

        aumento = salario * 0.15;

        operarios++;

        netoOperarios += (salario + aumento) * 0.9083;

    }

    else if (tipo == 2)

    {

        aumento = salario * 0.10;

        tecnicos++;

        netoTecnicos += (salario + aumento) * 0.9083;

    }

    else if (tipo == 3)

    {

        aumento = salario * 0.05;

        profesionales++;

        netoProfesionales += (salario + aumento) * 0.9083;

    }

    //Llamado al método 1

    resultados(cedula, nombre, salario, aumento);


    Console.Write("\n Desea ingresar otro empleado (s/n): ");

    seguir = Console.ReadLine();

}

//Llamado al método-función 2

resultados_Operarios(operarios, tecnicos, profesionales, netoOperarios, netoTecnicos, netoProfesionales);


//Método-función 1 

void resultados(string cedula, string nombre, double salario, double aumento)
{


    double bruto = salario + aumento;

    double deduccion = bruto * 0.0917;

    double neto = bruto - deduccion;

    Console.WriteLine("\n--- Resultado ---");

    Console.WriteLine("Cédula: " + cedula);

    Console.WriteLine("Nombre: " + nombre);

    Console.WriteLine("Salario Ordinario: " + salario);

    Console.WriteLine("Aumento: " + aumento);

    Console.WriteLine("Salario Bruto: " + bruto);

    Console.WriteLine("Deducción: " + deduccion);

    Console.WriteLine("Salario Neto: " + neto);

}

//Método 2-función 

void resultados_Operarios(int operarios, int tecnicos, int profesionales, double netoOperarios, double netoTecnicos, double netoProfesionales)
{

    Console.WriteLine("\n Resultados ");

    if (operarios > 0)
    {

        Console.WriteLine("Operarios: " + operarios);

        Console.WriteLine("Total Neto: " + netoOperarios);

        Console.WriteLine("Promedio Neto: " + (netoOperarios / operarios));

    }

    if (tecnicos > 0)
    {

        Console.WriteLine("Tecnicos: " + tecnicos);

        Console.WriteLine("Total Neto: " + netoTecnicos);

        Console.WriteLine("Promedio Neto: " + (netoTecnicos / tecnicos));

    }

    if (profesionales > 0)
    {

        Console.WriteLine("Profesionales: " + profesionales);

        Console.WriteLine("Total Neto: " + netoProfesionales);

        Console.WriteLine("Promedio Neto: " + (netoProfesionales / profesionales));

    }

}


static double fnsalario(double horas, double precio)
{

    double salario = horas * precio;

    return salario;

}


