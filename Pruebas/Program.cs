using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pruebas
{
    public class Program
    {
        static SortedList alumnos = new SortedList();
        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese una opcion: ");
                Console.WriteLine("1 - Ingresar un nuevo alumno");
                Console.WriteLine("2 - Listar todos los alumnos");
                Console.WriteLine("3 - Listar alumnos por nombre");
                Console.WriteLine("4 - Buscar por legajo");
                Console.WriteLine("5 - Eliminar alumno al azar");
                Console.WriteLine("6 - Eliminar todos los alumnos");
                Console.WriteLine("7 - Salir del programa");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result > 0 && result < 8)
                    {
                        if (result == 7)
                        {
                            break;
                        }

                        try
                        {
                            Menu(result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                            Console.WriteLine("Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar una opcion valida!");
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese números!");
                }

            } while (true);
            MostrarSaludo();
        }

        public static void MostrarSaludo()
        {
            string mensaje = "Muchas gracias por utilizar el sistema!";
            char[] msj = mensaje.ToCharArray();

            foreach (var item in msj)
            {
                Console.Write(item);
                if (item == ' ')
                {
                    Thread.Sleep(60);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            Thread.Sleep(600);
        }

        public static void Menu(int opcion)
        {
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    CargarAlumno(alumnos);
                    break;
                case 2:
                    MostrarAlumnos(alumnos);
                    break;
                case 3:
                    if (alumnos.Count == 0)
                    {
                        throw new FormatException("No hay alumnos cargados!");
                    }
                    Console.Write("Ingrese un nombre: ");
                    string entrada = Console.ReadLine();
                    MostrarAlumnos(alumnos, entrada);
                    break;
                case 4:
                    BuscarYMostrarAlumno(alumnos);
                    break;
                case 5:
                    alumnos = EliminarAlumnoAlAzar(alumnos);
                    break;
                case 6:
                    alumnos = EliminarTodosLosAlumnos(alumnos);
                    break;
                default:
                    throw new ArgumentException("No se a dado un argumento valido");
            }
        }

        public static SortedList EliminarTodosLosAlumnos(SortedList alumnos)
        {
            if (alumnos.Count == 0)
            {
                throw new FormatException("No hay alumnos cargados!");
            }

            do
            {
                Console.WriteLine("¿De verdad quiere eliminar todos los alumnos? S/n");
                string entrada = Console.ReadLine();

                if (entrada.ToLower() == "n")
                {
                    return alumnos;
                }
                else if (entrada.ToLower() == "s")
                {
                    alumnos.Clear();
                    return alumnos;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese solo las opciones validas!");
                }
            } while (true);
        }

        public static SortedList EliminarAlumnoAlAzar(SortedList alumnos)
        {
            if (alumnos.Count == 0)
            {
                throw new FormatException("No hay alumnos cargados!");
            }

            Random rnd = new Random();
            int random = rnd.Next(0, alumnos.Count - 1);

            alumnos.RemoveAt(random);

            return alumnos;
        }

        public static void BuscarYMostrarAlumno(SortedList alumnos)
        {
            if (alumnos.Count == 0)
            {
                throw new FormatException("No hay alumnos cargados!");
            }

            int legajo;
            do
            {
                Console.WriteLine("Ingrese un legajo: ");
                if (int.TryParse(Console.ReadLine(), out legajo))
                {
                    if (legajo > 99 && legajo < 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un número de tres digitos");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese números!");
                }
            } while (true);

            try
            {
                if (VerificarLegajo(legajo, alumnos))
                {
                    Console.WriteLine("No existe el legajo ingresado");
                }
                else
                {
                    var item = alumnos[legajo];

                    Console.WriteLine("Alumno con el legajo: {0} y el nombre {1}", legajo, item);
                }
            }
            catch (Exception)
            {
                throw;
            }

            

            Console.WriteLine("Ingrese una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarAlumnos(SortedList alumnos)
        {
            if (alumnos.Count == 0)
            {
                throw new FormatException("No hay alumnos cargados!");
            }

            foreach (DictionaryEntry item in alumnos)
            {
                Console.WriteLine("Alumno con el legajo: {0} y el nombre {1}", item.Key, item.Value);
            }

            Console.WriteLine("Ingrese una tecla para continuar");
            Console.ReadKey();
        }

        public static void MostrarAlumnos(SortedList alumnos, string entrada)
        {
            if (alumnos.Count == 0)
            {
                throw new FormatException("No hay alumnos cargados!");
            }

            if (string.IsNullOrWhiteSpace(entrada))
            {
                throw new ArgumentNullException(entrada, "Debe ingresar un nombre");
            }

            foreach (DictionaryEntry item in alumnos)
            {
                if (item.Value.ToString().StartsWith(entrada))
                {
                    Console.WriteLine("Alumno con el legajo: {0} y el nombre {1}", item.Key, item.Value);
                }
            }

            Console.WriteLine("Ingrese una tecla para continuar");
            Console.ReadKey();
        }

        public static void CargarAlumno(SortedList alumnos)
        {
            int legajo;
            do
            {
                Console.Write("Ingrese el legajo: ");
                if (int.TryParse(Console.ReadLine(), out legajo))
                {
                    if (legajo > 99 && legajo < 1000)
                    {
                        try
                        {
                            if (VerificarLegajo(legajo, alumnos))
                            {
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese un legajo no repetido!");
                            }

                        }
                        catch (FormatException)
                        {
                            break;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese números de tres cifras");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese un número");
                }
            } while (true);

            do
            {
                Console.Write("Ingrese un nombre: ");
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    if (IsNameValid(entrada))
                    {
                        alumnos.Add(legajo, entrada);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un nombre valido!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese un nombre!");
                }

            } while (true);

            Program.alumnos = alumnos;
        }

        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            char[] vs = name.ToCharArray();

            int cnt = (from item in vs
                       where char.IsLetter(item)
                       select item).Count();

            return cnt == name.Length;
        }

        public static bool VerificarLegajo(int legajo, SortedList alumnos)
        {
            if (legajo <= 99 || legajo >= 1000)
            {
                throw new Exception("El legajo debe tener 3 digitos!");
            }

            if (alumnos.Count == 0)
            {
                throw new FormatException();
            }

            return !alumnos.ContainsKey(legajo);
        }
    }
}
