using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        // ------------------------- Propiedades -------------------------
        private int _codTurno;
        private int _legajoMedico;
        private DateTime _fecha;
        private bool _pendiente;
        private bool _asistencia;
        private string _descripcion;
        private bool _estado;

        // ------------------------- Constructores -------------------------
        public Turno() { } //Uno vacío obligatorio.

        public Turno(int codTurno, int legajoMedico, DateTime fecha, bool pendiente, bool asistencia, string descripcion, bool estado)
        {
            _codTurno = codTurno;
            _legajoMedico = legajoMedico;
            _fecha = fecha;
            _pendiente = pendiente;
            _asistencia = asistencia;
            _descripcion = descripcion;
            _estado = estado;
        }

        // ------------------------- Getters y Setters -------------------------
        public int CodTurno
        {
            get { return _codTurno; }
            set { _codTurno = value; }
        }

        public int LegajoMedico
        {
            get { return _legajoMedico; }
            set { _legajoMedico = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public bool Pendiente
        {
            get { return _pendiente; }
            set { _pendiente = value; }
        }

        public bool Asistencia
        {
            get { return _asistencia; }
            set { _asistencia = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
