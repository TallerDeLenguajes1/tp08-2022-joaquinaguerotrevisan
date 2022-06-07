using System.IO;

namespace IndexadorCarpeta{

    class Program{

        static int Main(string[] args){

            Console.WriteLine("============ Indexador de Carpetas ============\n");

            Console.WriteLine(" - Ingrese el Directorio de una carpeta: ");
            string? Directorio = Convert.ToString(Console.ReadLine());

            MostrarCarpetaYGuardar(Directorio);

            Console.WriteLine("\n===============================================");

            return 0;
        }

        static bool ExisteCarpeta(string NombreDirectorio){

            if (Directory.Exists(NombreDirectorio))
            {
                Console.WriteLine("   \nEl Directorio existe.\n");
                return true;

            } else 
            {
                Console.WriteLine("   \nEL DIRECTORIO NO EXISTE.\n");
                return false;
            }

        }

        static void MostrarCarpetaYGuardar(string NombreDirectorio){

            if (ExisteCarpeta(NombreDirectorio))
            {
                int Guardar = 0;

                Console.WriteLine(" - Desea guardar las carpetas y archivos del directorio?: ");
                Guardar = Convert.ToInt32(Console.ReadLine());

                string RutaNotas = @"C:\Users\joaqu\Desktop\Transportar\2Anio_1C\Taller_de_Lenguajes\tp08-2022-joaquinaguerotrevisan\EJ1\Notas.csv";
                StreamWriter sr = new StreamWriter(RutaNotas);
                sr.WriteLine("Indice;NombreDelArchivo;Nota");
                int Indice = 0;
                
                List<string> ListadoDeCarpetas = Directory.GetDirectories(NombreDirectorio).ToList();
                Console.WriteLine("\n - Elementos encontrados:\n");

                foreach (string item in Directory.GetFiles(NombreDirectorio))
                {
                    var NombreItem = item.Split("\\");
                    Console.WriteLine("   -> " + NombreItem[NombreItem.Length - 1]);

                    if (Guardar == 1)
                    {
                        GuardarCarpeta(NombreItem[NombreItem.Length - 1], Indice, sr);
                        Indice++;
                    }

                }

                foreach (string CarpetaY in ListadoDeCarpetas)
                {   
                    var NombreCarpeta = CarpetaY.Split("\\");
                    Console.WriteLine("   File: " + NombreCarpeta[NombreCarpeta.Length - 1]);
                    
                    if (Guardar == 1)
                    {
                        GuardarCarpeta(NombreCarpeta[NombreCarpeta.Length - 1], Indice, sr);
                        Indice++;
                    }

                    foreach (string item in Directory.GetFiles(CarpetaY))
                    {
                        var NombreItem = item.Split("\\");
                        Console.WriteLine("    -> " + NombreItem[NombreItem.Length - 1]);

                        if (Guardar == 1)
                        {
                            GuardarCarpeta(NombreItem[NombreItem.Length - 1], Indice, sr);
                            Indice++;
                        }
                    }

                    if (Guardar == 1)
                    {
                        Indice ++;
                    }  
                }

                sr.Close();
            }
        }

        static void GuardarCarpeta(string NombreDirectorio, int Indice, StreamWriter sr){

            var Nombre = NombreDirectorio.Split(".");
            sr.WriteLine(Indice + ";" + Nombre[0] + ";" + Nombre[1]);

        }
    }
}