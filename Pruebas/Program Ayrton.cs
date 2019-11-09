using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Prueba_1
{
    class Program
    {
        public static SortedList lista = new SortedList();
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Menu();
                    if (int.TryParse(Console.ReadLine(), out int resultado))
                    {
                        if (resultado == 7)
                        {
                            break;
                        }

                        SwichMenu(resultado);
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado no es valido. Presione cualquier tecla para volver al menu");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
                
            } while (true);
        }

        public static void Menu()
        {
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("*       1- Agregar alumno                                                         *");
            Console.WriteLine("*       2- Listar todos los alumnos                                               *");
            Console.WriteLine("*       3- Listar todos los alumnos cuyo nombre comience con una cadena           *");
            Console.WriteLine("*       4-Mostrar el nombre del alumno cuyo legajo coincida con el ingresado      *");
            Console.WriteLine("*       5-Eliminar un alumno de la coleccion                                      *");
            Console.WriteLine("*       6-Eliminar todos los alumnos ingresados                                   *");
            Console.WriteLine("*       7-Salir del programa                                                      *");
            Console.WriteLine("***********************************************************************************");
        } //Menu
        public static void SwichMenu(int opcion)
        {
            int validacionLegajo;
            string validacionNombre;
            int validacionDeLegajoABuscar;
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("Ingrese legajo: ");
                        if (int.TryParse(Console.ReadLine(), out validacionLegajo))
                        {
                            if (validacionLegajo > 100 && validacionLegajo < 1000)
                            {
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("El numero debe de ser de 3 digitos.");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("El valor debe de ser un numero");
                        }
                    } while (true);


                    do
                    {
                        Console.WriteLine("Ingrese nombre del alumno: ");
                        validacionNombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(validacionNombre)) //Validacion de que no es nulo ni vacio
                        {
                            //if (!int.TryParse(Console.ReadLine(), out validacionDosNombre)) //Validacion de que no es un numero
                            //{
                            //    break;
                            //}
                            //else
                            //{
                            //    Console.WriteLine("No se puede ingresar numeros.");
                            //}

                            break;
                        }
                        else
                        {
                            Console.WriteLine("El valor no puede ser nulo ni vacio.");
                        }
                    } while (true);

                    lista.Add(validacionLegajo, validacionNombre);
                    Console.WriteLine("Valores cargados.");
                    Console.WriteLine("Presione una tecla para salir al menu...");
                    Console.ReadKey();
                    break;

                case 2:
                    if (lista.Count == 0)
                    {
                        throw new Exception("La lista esta vacia");
                    }

                    Console.Clear();
                    foreach (DictionaryEntry item in lista)
                    {
                        Console.WriteLine("Los valores son: {0} - {1}", item.Key, item.Value);
                    }
                    break;
                case 3:
                    Console.WriteLine("Ingrese cadena a buscar: ");
                    string texto = Console.ReadLine();
                    foreach (DictionaryEntry item in lista)
                    {
                        if (item.Value.ToString().StartsWith(texto))
                        {
                            Console.WriteLine("Los alumnos son: {0}", item.Value);
                            Console.WriteLine("Presione una tecla para salir al menu...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Ingrese legajo a buscar: ");
                    if (!int.TryParse(Console.ReadLine(), out validacionDeLegajoABuscar))
                    {
                        if (validacionDeLegajoABuscar > 99 && validacionDeLegajoABuscar < 1000)
                        {
                            foreach (DictionaryEntry item in lista)
                            {
                                if (Convert.ToInt32(item.Key) == validacionDeLegajoABuscar)
                                {
                                    Console.WriteLine("Los alumnos son: {0}", item.Key);
                                    Console.WriteLine("Presione una tecla para salir...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("No hay valor");
                                }
                            }

                            //Forma de hacerlo de Cris
                            //if (lista.ContainsKey(validacionDeLegajoABuscar))
                            //{
                            //    var item = lista.GetKey(validacionDeLegajoABuscar);
                            //    Console.WriteLine("");
                            //}

                            //Forma de hacer lo de Martin
                        }
                        else
                        {
                            Console.WriteLine("El legajo debe de ser de 3 digitos");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El valor debe de ser un numero");
                    }
                    break;
                default:
                    break;
            }
        } //Swich menu
    }
}