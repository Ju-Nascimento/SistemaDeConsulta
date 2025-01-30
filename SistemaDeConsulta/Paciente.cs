using System;
using System.Collections.Generic;

public static class Paciente
{
    public static void AddPaciente(List<Dictionary<string, string>> pacientes)
    {
        Console.Write("Nome do paciente: ");
        string nome = Console.ReadLine();
        Console.Write("Telefone do paciente: ");
        string telefone = Console.ReadLine();
        Console.Write("Email do paciente: ");
        string email = Console.ReadLine();
        Console.Write("CPF do paciente: ");
        string cpf = Console.ReadLine();

        var paciente = new Dictionary<string, string>
        {
            { "nome", nome },
            { "telefone", telefone },
            { "email", email },
            { "cpf", cpf }
        };

        pacientes.Add(paciente);
        Console.WriteLine($"Paciente {nome} cadastrado com sucesso.");
    }
}
