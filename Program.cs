using System;

Console.WriteLine("BIBLIOTECA SOLIDARISTA");
Console.WriteLine("Este sistema ayuda a gestionar el préstamo de libros para los asociados.");
Console.WriteLine("Permite llevar un control del catálogo y registrar los prestamos.");
Console.WriteLine("Mantiene un registro del estado de cada prestamo y su duracion.");
Console.WriteLine("Facilita el seguimiento de material bibliográfico de la asociación.");

//Array-vector de libros variable global
string[] libros = new string[8] {
    "Cien años de soledad",
    "El principito",
    "Don Quijote",
    "La Odisea",
    "Narnia",
    "Titanic",
    "Paco y lola",
    "Unica mirando al mar"
};

// Matriz para los prestamos 20 filas y 3 columnas (libro, dias, estado)
int[,] prestamos = new int[20, 3];
int contadorPrestamos = 0;

string seguir = "s";

while (seguir == "s")
{
    //Menu
    Console.WriteLine("Bienvenidos");
    Console.WriteLine("1. Ver lista de libros");
    Console.WriteLine("2. Solicitar libro");
    Console.WriteLine("3. Ver prestamos");
    Console.WriteLine("4. Entregar libro");
    Console.WriteLine("5. Salir");

    Console.Write("\nSeleccione una opción: ");
    int opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            verlibros();
            break;
        case 2:
            solicitarlibro();
            break;
        case 3:
            verprestamos();
            break;
        case 4:
            entregarlibro();
            break;
        case 5:
            seguir = "n";
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
}

mostrarResumen(contadorPrestamos);

// Funciones del sistema
void verlibros()
{

    Console.WriteLine("LIBROS DISPONIBLES:");
    for (int i = 0; i < libros.Length; i++)
    {
        Console.WriteLine($"{i}. {libros[i]}");
    }
}

void solicitarlibro()
{

    if (contadorPrestamos >= 20)
    {

        Console.WriteLine("\nha excedido el máximo");
        return;
    }

    verlibros();

    Console.Write("\nIngrese el número del libro: ");
    int indiceLibro = int.Parse(Console.ReadLine());

    if (indiceLibro >= 0 && indiceLibro < libros.Length)
    {

        Console.Write("Ingrese la cantidad de dias del prestamo: ");
        int dias = int.Parse(Console.ReadLine());

        prestamos[contadorPrestamos, 0] = indiceLibro;
        prestamos[contadorPrestamos, 1] = dias;
        prestamos[contadorPrestamos, 2] = 1;
        contadorPrestamos++;

        Console.WriteLine("exito.");

    }
    else
    {
        Console.WriteLine("seleccione uno correcto");
    }
}

void verprestamos()
{
    Console.WriteLine("\nREGISTRO DE PRESTAMOS:");
    Console.WriteLine("ID    LIBRO     DIAS       ESTADO");

    for (int i = 0; i < contadorPrestamos; i++)
    {

        string estado;

        if (prestamos[i, 2] == 0)
        {

            estado = "Cancelado";
        }
        else if (prestamos[i, 2] == 1)
        {
            estado = "Activo";

        }
        else
        {
            estado = "Finalizado";
        }

        Console.WriteLine("ID: " + i + " - Libro: " + libros[prestamos[i, 0]] + " - Días: " + prestamos[i, 1] + " - Estado: " + estado);
    }
}

void entregarlibro()
{

    verlibros();
    Console.Write("\nIngrese el numero del prestamo a modificar: ");
    int numero = int.Parse(Console.ReadLine());

    if (numero >= 0 && numero < contadorPrestamos)
    {
        Console.WriteLine("Estados disponibles:");
        Console.WriteLine("0 - Cancelado");
        Console.WriteLine("1 - Activo");
        Console.WriteLine("2 - Finalizado");
        Console.Write("Ingrese el nuevo estado: ");
        int nuevoEstado = int.Parse(Console.ReadLine());

        if (nuevoEstado >= 0 && nuevoEstado <= 2)
        {

            prestamos[numero, 2] = nuevoEstado;
            Console.WriteLine("Estado actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Estado no válido.");
        }
    }
    else
    {
        Console.WriteLine("ID de préstamo no válido.");
    }
}

void mostrarResumen(int totalPrestamos)
{
    int activos = 0;
    int cancelados = 0;
    int finalizados = 0;

    for (int i = 0; i < totalPrestamos; i++)
    {

        switch (prestamos[i, 2])
        {
            case 0: cancelados++; break;
            case 1: activos++; break;
            case 2: finalizados++; break;
        }
    }

    Console.WriteLine("\nRESUMEN FINAL");
    Console.WriteLine($"Total de prestamos: {totalPrestamos}");
    Console.WriteLine($"Prestamos activos: {activos}");
    Console.WriteLine($"Prestamos cancelados: {cancelados}");
    Console.WriteLine($"Prestamos finalizados: {finalizados}");
}