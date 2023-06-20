using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int N_Estudiantes = 0;
                int N_years = 0;
                int aulas = 0;
                string Nombre_Carrera = string.Empty;

                Console.Write("\n- Ingrese el número de estudiantes: ");
                N_Estudiantes = Convert.ToInt32(Console.ReadLine());

                Console.Write("\n- Ingrese el número de años: ");
                N_years = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n - Ingrese el nombre de la carrera: ");
                Nombre_Carrera = Console.ReadLine();

                Console.WriteLine($"- Nombre de la carrera: {Nombre_Carrera} ");

                int[] pasaron = new int[N_years];
                int[] quemados = new int[N_years];
                int[] cojieron_miedo = new int[N_years];

                int N_EstudiantesInicial = N_Estudiantes;

                for (int i = 0; i < N_years; i++)
                {
                    Random random = new Random();

                    pasaron[i] = random.Next(70, 101);
                    quemados[i] = random.Next(60, 69);
                    cojieron_miedo[i] = random.Next(0, 10);
                }

                int[] M_inscrita = new int[N_years * 3];
                int[] E_aprobados = new int[N_years * 3];
                int[] E_reprobados = new int[N_years * 3];
                int[] E_abandonaron = new int[N_years * 3];

                for (int año = 1; año <= N_years; año++)
                {
                    for (int semestre = 1; semestre <= 3; semestre++)
                    {
                        int indice = (año - 1) * 3 + semestre - 1;

                        M_inscrita[indice] = N_Estudiantes;

                        Random random = new Random();

                        E_aprobados[indice] = (int)(N_Estudiantes * (pasaron[año - 1] / 100.0));
                        E_reprobados[indice] = (int)(N_Estudiantes * (quemados[año - 1] / 100.0));
                        E_abandonaron[indice] = (int)(N_Estudiantes * (cojieron_miedo[año - 1] / 100.0));

                        N_Estudiantes -= E_abandonaron[indice];

                        aulas = (int)Math.Ceiling((double)N_Estudiantes / 30);

                        Console.WriteLine("\n ------ Año {0} - Semestre {1} ------", año, semestre);
                        Console.WriteLine(" \n\t- Matriculados: {0} - \n\t - Aprobados: {1} - \n\t - Repitentes: {2} - \n\t - Abandonaron: {3} - \n\t - Aulas disponibles: {4} - \n\n",
                            M_inscrita[indice], E_aprobados[indice], E_reprobados[indice], E_abandonaron[indice], aulas);
                    }
                }

                int ultimoAño = N_years;
                int ultimoSemestre = 3;
                int indiceUltimo = (ultimoAño - 1) * 3 + ultimoSemestre - 1;
                int ultimoAulaInicial = (ultimoAño - 1) * 3 + 1;

                aulas = (int)Math.Ceiling((double)N_EstudiantesInicial / 30);
                Console.WriteLine("\nTotal de aulas requeridas en el último semestre: {0}", aulas);

                Console.Write("Pulsa cualquier otra tecla para ejecutar de nuevo o 'S' para salir: ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "S")
                {
                    break;
                }

                Console.Clear();

            } while (true);
        }
    }
}
