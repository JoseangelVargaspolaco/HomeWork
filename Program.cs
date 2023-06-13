using System;

namespace HomeWork
{
    class HomeWork
    {
        public static void Main(string[] args)
        {
            // Bucle principal para volver a ejecutar el programa
            do
            {
                int N_Estudiantes = 0; 
                int N_years = 0;
                string Nombre_Carrera = "Ingenieria en sistemas"; 
                int T_estudents = 0;

                // Solicitar al usuario el número de estudiantes
                Console.Write("\n- Ingrese el número de estudiantes: ");
                N_Estudiantes = Convert.ToInt32(Console.ReadLine());

                // Solicitar al usuario el número de años de la carrera
                Console.Write("- Ingrese el número de años de la carrera: ");
                N_years = Convert.ToInt32(Console.ReadLine());

                // Validar que el número de años esté dentro del rango válido (1-5)
                while (N_years < 1 || N_years > 5)
                {
                    Console.Clear();
                    Console.WriteLine("\n- El número de años debe estar entre 1-5.");
                    Console.Write("- Ingrese el número de años de la carrera (1-5): ");
                    N_years = Convert.ToInt32(Console.ReadLine());
                }

                // Solicitar al usuario el nombre de la carrera
                Console.Write($"- Nombre de la carrera: {Nombre_Carrera}");

                //Probabilidad de que los estudiantes que pasen, se quemen o de asusten desde el primer año hasta el quinto año
                double[] pasaron = { 0.7, 0.7, 0.7, 0.7, 0.7 };
                double[] quemados = { 0.2, 0.2, 0.2, 0.2, 0.2 }; 
                double[] cojieron_miedo = { 0.1, 0.1, 0.1, 0.1, 0.1 }; 

                int[] M_inscrita = new int[N_years]; // Matrículas inscritas por año
                int[] E_aprobados = new int[N_years]; // Aprobados por año
                int[] E_reprobados = new int[N_years]; // Reprobados por año
                int[] E_abandonaron = new int[N_years]; // Abandonos por año

                // Ciclo para simular los años de la carrera
                for (int i = 0; i < N_years; i++)
                {
                    M_inscrita[i] = N_Estudiantes;
                    E_aprobados[i] = (int)(N_Estudiantes * pasaron[i]); // Cálculo del número de estudiantes aprobados en el año i
                    E_abandonaron[i] = (int)(N_Estudiantes * quemados[i]); // Cálculo del número de estudiantes que abandonan en el año i
                    E_reprobados[i] = (int)(N_Estudiantes * cojieron_miedo[i]); // Cálculo del número de estudiantes reprobados en el año i
                    
                    N_Estudiantes = E_aprobados[i] + E_reprobados[i]; // Número de estudiantes que pasan al siguiente año
                }

                // Cálculo del número de aulas requeridas
                for (int y = 0; y < N_years; y++)
                {
                    T_estudents += M_inscrita[y];
                }

                int aulas = (int)Math.Ceiling((double)T_estudents / 30); // Considerando una capacidad de 30 estudiantes por aula

                // Imprimir resultados
                Console.WriteLine("\nResultados:");
                Console.WriteLine();
                Console.WriteLine($"Carrera: {Nombre_Carrera}\n");

                for (int e = 0; e < N_years; e++)
                {
                    Console.WriteLine($"Año {e + 1}:");
                    Console.WriteLine($"- Matriculados: {M_inscrita[e]}"); // Imprimir el número de estudiantes matriculados en el año i
                    Console.WriteLine($"- Aprobados: {E_aprobados[e]}"); // Imprimir el número de estudiantes aprobados en el año i
                    Console.WriteLine($"- Reprobados: {E_reprobados[e]}"); // Imprimir el número de estudiantes reprobados en el año i
                    Console.WriteLine($"- Abandonos: {E_abandonaron[e]}"); // Imprimir el número de estudiantes que abandonan en el año i
                    Console.WriteLine();
                }

                Console.WriteLine($"Total de aulas requeridas: {aulas}"); // Imprimir el número total de aulas requeridas

                // Validación para ejecutar de nuevo
                Console.WriteLine();
                Console.Write("Pulsa cualquier otra tecla para ejecutar de nuevo o si quieres salir ingresa 'S': ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "S" || input.ToUpper() == "s")
                {
                    break; // Salir del bucle principal y finalizar el programa
                }

                Console.Clear(); // Limpiar la consola antes de ejecutar nuevamente

            } while (true);
        }
    }
}

