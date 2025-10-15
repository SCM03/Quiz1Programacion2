class Program
//Falta de llaves en la clase y método principal
{
    static void Main()
    {
        string[] catalogo = { "A", "B", "C", "D", "E" }; //Hay caracteres invalidos como h, y y falta el cierre correcto de las llaves {}
        double[] precios = { 10.0, 15.0, 20.0, 25.0, 30.0 };
        int[,] registros = new int[50, 3];
        int contador = 0;
        int opcion = 0;

        do
        {
            Console.WriteLine("\n1. Registrar evento");
            Console.WriteLine("2. Mostrar registros");
            Console.WriteLine("3. Finalizar evento");
            Console.WriteLine("4. Salir \n");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                // Se pasa contador por referencia
                case 1: RegistrarEvento(registros, catalogo, precios, ref contador); break;
                case 2: MostrarRegistros(registros, catalogo, contador); break;
                case 3: FinalizarEvento(registros, catalogo, contador); break;
            }
        } while (opcion != 4);
    }

    // Se agrega ref para contador
    static void RegistrarEvento(int[,] matriz, string[] catalogo, double[] precios, ref int contador)
    {
        String codigo;
        Console.Write("Ingrese código (ej): A, B, C , D ó E ): ");
        codigo = Console.ReadLine();

        int pos = -1;

        //Se cambió <= por < para evitar fuera de rango
        for (int i = 0; i < catalogo.Length; i++) // Error 1
        {
            if (catalogo[i] == codigo)
                pos = i;
        }
        if (pos == -1)
            Console.WriteLine("Código no encontrado");
        else
        {
            Console.Write("Cantidad: ");
            double cantidad = Convert.ToDouble(Console.ReadLine());
            matriz[contador, 0] = pos;
            matriz[contador, 1] = (int)cantidad;
            matriz[contador, 2] = 1;
            contador++;
        }
    }

    static void MostrarRegistros(int[,] matriz, string[] catalogo, int contador)
    {
        for (int i = 0; i < contador; i++)
        {
            // Se cambió O mayúscula por 0
            Console.WriteLine("item: " + catalogo[matriz[i, 0]]);
        }
    }


    //Este codigo se relaciona con la matriz ya que busca el vector catalogo
    //compara la posición por ejemplo A=0, B=1, C=2, D=3, E=4
    //y busca en la matriz la posición 0,1,2,3,4
    //si encuentra la posición y el estado es 1 (activo) lo cambia a finalizado
    //cambando el valor 1 por 0
    static void FinalizarEvento(int[,] matriz, string[] catalogo, int contador)
    {
        string codigo;
        int pos = -1;

        // Validación con ciclo do-while para asegurar que el codigo existe
        do
        {
            Console.Write("Ingrese código del evento a finalizar: ");
            codigo = Console.ReadLine();

            for (int i = 0; i < catalogo.Length; i++)
            {
                if (catalogo[i] == codigo)
                    pos = i;
            }

            if (pos == -1)
                Console.WriteLine("Código no encontrado, intente nuevamente.");

        } while (pos == -1);

        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (matriz[i, 0] == pos && matriz[i, 2] == 1)
            {
                matriz[i, 2] = 0;
                Console.WriteLine("Evento finalizado.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
            Console.WriteLine("No se encontró un evento activo con ese código. ");
    }

}