using System;
using System.Collections.Generic;

public static class Consulta
{
    private static readonly List<string> Especialidades = new List<string> { "Psicologo", "Psiquiatra", "Fonoaudiologo" };

    public class SelecionadorDataHora
    {
        public DateTime? DataHoraSelecionada { get; private set; }

        public void SelecionarDataHora()
        {
            while (true)
            {
                Console.Write("Insira a data e hora da consulta (dd/mm/aaaa hh:mm): ");
                string dataHoraStr = Console.ReadLine();
                if (DateTime.TryParseExact(dataHoraStr, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime dataHora))
                {
                    DataHoraSelecionada = dataHora;
                    break;
                }
                else
                {
                    Console.WriteLine("Formato de data e hora inválido. Use o formato correto (dd/mm/aaaa hh:mm) e tente novamente.");
                }
            }
        }
    }

    public static void MarcarConsulta(List<Dictionary<string, string>> pacientes, List<Dictionary<string, object>> consultas)
    {
        if (pacientes.Count == 0)
        {
            Console.WriteLine("Não há pacientes cadastrados.");
            return;
        }

        Console.WriteLine("Escolha um paciente para a consulta:");
        for (int i = 0; i < pacientes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {pacientes[i]["nome"]}");
        }

        int pacienteIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        if (pacienteIndex < 0 || pacienteIndex >= pacientes.Count)
        {
            Console.WriteLine("Paciente inválido.");
            return;
        }

        var selecionador = new SelecionadorDataHora();
        selecionador.SelecionarDataHora();
        var dataHoraSelecionada = selecionador.DataHoraSelecionada;

        Console.WriteLine("Escolha a especialidade médica:");
        for (int i = 0; i < Especialidades.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {Especialidades[i]}");
        }

        int especialidadeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        if (especialidadeIndex < 0 || especialidadeIndex >= Especialidades.Count)
        {
            Console.WriteLine("Especialidade inválida.");
            return;
        }

        var consulta = new Dictionary<string, object>
        {
            { "paciente", pacientes[pacienteIndex] },
            { "data_hora", dataHoraSelecionada },
            { "especialidade", Especialidades[especialidadeIndex] }
        };

        consultas.Add(consulta);
        Console.WriteLine($"Consulta marcada para {pacientes[pacienteIndex]["nome"]} em {dataHoraSelecionada} com especialidade {Especialidades[especialidadeIndex]}.");
    }

    public static void ConsultasAgendadas(List<Dictionary<string, object>> consultas)
    {
        if (consultas.Count == 0)
        {
            Console.WriteLine("Não há consultas agendadas.");
            return;
        }

        foreach (var consulta in consultas)
        {
            var paciente = (Dictionary<string, string>)consulta["paciente"];
            Console.WriteLine($"{paciente["nome"]} - {consulta["data_hora"]} - {consulta["especialidade"]}");
        }
    }

    public static void CancelarConsulta(List<Dictionary<string, object>> consultas)
    {
        if (consultas.Count == 0)
        {
            Console.WriteLine("Não há consultas para cancelar.");
            return;
        }

        Console.WriteLine("Escolha uma consulta para cancelar:");
        for (int i = 0; i < consultas.Count; i++)
        {
            var consulta = consultas[i];
            var paciente = (Dictionary<string, string>)consulta["paciente"];
            Console.WriteLine($"{i + 1} - {paciente["nome"]} - {consulta["data_hora"]} - {consulta["especialidade"]}");
        }

        int consultaIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        if (consultaIndex < 0 || consultaIndex >= consultas.Count)
        {
            Console.WriteLine("Consulta inválida.");
            return;
        }

        var consultaCancelada = consultas[consultaIndex];
        consultas.RemoveAt(consultaIndex);
        var pacienteCancelado = (Dictionary<string, string>)consultaCancelada["paciente"];
        Console.WriteLine($"Consulta de {pacienteCancelado["nome"]} cancelada.");
    }
}
