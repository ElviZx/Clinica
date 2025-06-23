using System;
using System.Collections.Generic;

namespace ClinicaAgenda
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Paciente(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
    }

    public class Turno
    {
        public DateTime Fecha { get; set; }
        public Paciente Paciente { get; set; }

        public Turno(DateTime fecha, Paciente paciente)
        {
            Fecha = fecha;
            Paciente = paciente;
        }
    }

    public class Agenda
    {
        private List<Turno> turnos = new List<Turno>();

        public void AgregarTurno(DateTime fecha, Paciente paciente)
        {
            var nuevoTurno = new Turno(fecha, paciente);
            turnos.Add(nuevoTurno);
            Console.WriteLine($"Turno agendado para {paciente.Nombre} el {fecha:dd/MM/yyyy}");
        }

        public void MostrarTurnos()
        {
            Console.WriteLine("\nTurnos registrados:");
            foreach (var turno in turnos)
            {
                Console.WriteLine($"{turno.Paciente.Nombre} - {turno.Fecha:dd/MM/yyyy}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Agenda Médica\n");
            
            Agenda agenda = new Agenda();
            Paciente paciente = new Paciente("Elvis Marcillo", "0991234567");
            
            // Turno fijo 15/01/2025
            agenda.AgregarTurno(new DateTime(2025, 1, 15), paciente);
            
            agenda.MostrarTurnos();
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
