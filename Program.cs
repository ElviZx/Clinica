using System;
using System.Collections.Generic;

namespace ClinicaAgenda
{
    /// <summary>
    /// Clase que representa un paciente de la clínica
    /// </summary>
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

    /// <summary>
    /// Clase que representa un turno médico
    /// </summary>
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

    /// <summary>
    /// Clase principal que gestiona la agenda de turnos
    /// </summary>
    public class Agenda
    {
        private List<Turno> turnos = new List<Turno>();

        /// <summary>
        /// Agrega un nuevo turno al sistema
        /// </summary>
        public void AgregarTurno(DateTime fecha, Paciente paciente)
        {
            // Validación básica
            if (fecha < DateTime.Now)
            {
                Console.WriteLine("Error: No se pueden agendar turnos en fechas pasadas");
                return;
            }

            var nuevoTurno = new Turno(fecha, paciente);
            turnos.Add(nuevoTurno);
            Console.WriteLine($"Turno agendado para {paciente.Nombre} el {fecha:d}");
        }

        /// <summary>
        /// Consulta todos los turnos existentes
        /// </summary>
        public void ConsultarTodosLosTurnos()
        {
            Console.WriteLine("\nListado completo de turnos:");
            foreach (var turno in turnos)
            {
                Console.WriteLine($"{turno.Paciente.Nombre} - Tel: {turno.Paciente.Telefono} - Fecha: {turno.Fecha:d}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Gestión de Turnos Médicos ===");
            
            Agenda agenda = new Agenda();
            Paciente paciente = new Paciente("Elvis Marcillo", "0991234567");
            
            // Agendar turno fijo para el 15/01/2025
            agenda.AgregarTurno(new DateTime(2025, 1, 15), paciente);
            
            // Mostrar todos los turnos
            agenda.ConsultarTodosLosTurnos();
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
