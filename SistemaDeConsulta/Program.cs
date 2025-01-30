using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var pacientes = new List<Dictionary<string, string>>(); // Lista para armazenar pacientes cadastrados
        var consultas = new List<Dictionary<string, object>>(); // Lista para armazenar consultas agendadas

        while (true)
        {
            Menu();
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Paciente.AddPaciente(pacientes);
                    break;
                case 2:
                    Consulta.MarcarConsulta(pacientes, consultas);
                    break;
                case 3:
                    Consulta.ConsultasAgendadas(consultas);
                    break;
                case 4:
                    Consulta.CancelarConsulta(consultas);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }

    static void Menu()
    {
        Console.WriteLine("1 - Cadastrar paciente");
        Console.WriteLine("2 - Nova consulta");
        Console.WriteLine("3 - Consultas agendadas");
        Console.WriteLine("4 - Cancelar consultas");
        Console.WriteLine("5 - Sair");
    }
}
