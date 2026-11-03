//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text; 
 
namespace SistemaBiblioteca1.Models  
{ 
    public interface IAlmacenamientoCRUD
    {
        void InsertarRegistro(Object objeto);
        object ConsultarRegistro(string id);
        void ActualizarRegistro(object objeto);
        void EliminarRegistro(String id);
    } 
} 